using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController cc;
	private bool isJumping = false;
	private bool isFalling = false;
	private float speed = 30f;
	private float jumpSpeed = 10f;
	float currJump = 0;
	float allowedJump = 30;
	private bool isGrounded;
	void Update () {
		Ray myRay = new Ray(transform.position, Vector3.down);
		float myRaycastMacDist = 2f;
		Debug.DrawRay(myRay.origin, myRay.direction * myRaycastMacDist, Color.yellow);
		if (Physics.Raycast(myRay, myRaycastMacDist))
		{
			//if true (if the raycast hit collider), then...
			Debug.Log("grounded!");
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
		
		
		//Vector3 moveDirectionForward = transform.forward;
		Vector3 moveDirectionForward = transform.forward;//new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		Vector3 moveDirectionRight = transform.right;
		if (Input.GetKey(KeyCode.W))
		{
			
			cc.Move(moveDirectionForward*speed*Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
		
			cc.Move(moveDirectionForward*-speed*Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A))
		{
			//transform.eulerAngles += new Vector3(0f,-3f,0f);
			cc.Move(moveDirectionRight*-speed*Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			//transform.eulerAngles += new Vector3(0f,3f,0f);
			cc.Move(moveDirectionRight*speed*Time.deltaTime);
		}
		
	
		if (Input.GetKeyDown(KeyCode.Space) &&  isJumping == false  && isFalling == false)
		{
			isJumping = true;
			Jump();
		}
 
		if (isJumping == true && isFalling == false)
		{
			Jump();
		}
 
		if (isFalling == true && isJumping == false)
		{
			Fall();
		}
	}
	public void Jump()
	{
 
		if (currJump < allowedJump)
		{
			float temp = 0.0f;
			temp = Mathf.Sin(Time.deltaTime) * jumpSpeed;
			currJump += temp;
			cc.Move(Vector3.up * temp * Time.deltaTime * jumpSpeed);
		}
		else
		{
			isJumping = false;
			isFalling = true;
		}
	}
 
	public void Fall()
	{
		if (isGrounded == false)
		{
			float temp = 0.0f;
			temp = Mathf.Sin(Time.deltaTime) * jumpSpeed;
			currJump -= temp;
			cc.Move(Vector3.up * temp * Time.deltaTime * jumpSpeed * -1);
		}
		else
		{
			isFalling = false;
			currJump = 0;
		}
	}
}