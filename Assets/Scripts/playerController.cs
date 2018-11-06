using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//put this ona  capsule with a rigidbody
//this should handle mouselook as well was WASD movmement
public class playerController : MonoBehaviour
{
	public float moveSpeed = 10f;
	public float lookSpeed = 300f;
	private Vector3 inputVector;	//pass keyboard data from Update() to FixedUpdate()
	
	//length of item pick up raycast
	float maxRaycastDist = 2f;
	//bool to see if raycast hit a pick up item
	public bool itemHit;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame, this is where INPUT and RENDERING happens
	void Update () 
	{
		//mouse look
		//mouseDelta = difference, how fast you're moving your mouse
		//if delta is "0" that means the mouse isn't moving
		//this is NOT mouse position (mouse position is Input.mousePosition)
		float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;	//mouseX = horizontal mouseDelta
		float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;	//mouseY = vertical mouseDelta

		//simplest possible mouse-look
		//rotate the camera with mouse data
		//Camera.main.transform.Rotate(-mouseY, mouseX, 0f);
		
		//slightly better mouse=look
		//rotate capsule left/right, but rotate camera up/down
		//since this is in capsule you can get capsule transform
		transform.Rotate(0f, mouseX, 0f);
		//Camera.main.transform.localEulerAngles += new Vector3(-mouseY, 0f, 0f); //camera rotation
		Camera.main.transform.Rotate(-mouseY, 0f,0f); //same thing
		
		//rotating on x axis is pitch (look up and down)
		//rotating on y axis is yaw (look left and right)
		//rotating on z axis is roll
		
		//problem 1: camera keeps rolling
		//solution 1: after applying rotations, unroll the camera
		Camera.main.transform.localEulerAngles -= new Vector3(
			0,
			0,
			Camera.main.transform.localEulerAngles.z
		);
		
		//--------------
		
		//Player movement
		float vertical = Input.GetAxis("Vertical"); //vertical is for W/S or Up/Down on keyboard
		float horizontal = Input.GetAxis("Horizontal");
		
		//simplest possible thing: move transform based on keyboard values
		//vertical (forward) movement
		//we multiply by Time.deltaTime to make it "framerate Independent", more consistent
		//transform.position += transform.forward * vertical * moveSpeed * Time.deltaTime;
		//transform.position += transform.right * horizontal * moveSpeed * Time.deltaTime;
		
		
		//this simplest method is bad because we are moving transform directly
		// when you move transform directly you're basically teleporting it, no collision detection
		
		//a better method: move using Rigidbody forces in Fixedupdate(), which won't have same problems
		inputVector = transform.forward * vertical * moveSpeed;	//forward/back
		inputVector += transform.right * horizontal * moveSpeed;	//left/right
		
		//--------------------------
		//aim pickUpRay raycast
		Ray pickUpRay = Camera.main.ScreenPointToRay(transform.position);
		
		Debug.DrawRay(pickUpRay.origin, pickUpRay.direction * maxRaycastDist, Color.red);
		
		RaycastHit pickUpRayHit = new RaycastHit();	
		//if raycast hits something...
		if (Physics.Raycast(pickUpRay, out pickUpRayHit, maxRaycastDist))
		{
			if (pickUpRayHit.collider.tag == "gun")
			{
				if (Input.GetKey(KeyCode.E))
				{
					Debug.Log("you can pick it up!");
					itemHit = true;
				}
			}
			else
			{
				itemHit = false;
			}
			
		}
		
	}

	//FixedUpdate runs all the time, every physics frame(physics run at a different framerate than everything
	//all physics code need to go into FixedUpdate
	void FixedUpdate()
	{
		//apply our forces to move the object around
		GetComponent<Rigidbody>().velocity = inputVector; //no need for Time.deltaTime, already fixed framerate
	}
}
