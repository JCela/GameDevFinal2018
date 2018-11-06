using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeProtoMiove : MonoBehaviour
{


	public float CubeSpeed = 0.5f; //normal speed of the cube
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) //if W is pressed 
		{
			transform.Translate(0.2f * CubeSpeed, 0f,0f); //moving the cube
			
			Time.timeScale = 1;	//setting time to "normal time" when you move
		}

		else
		{
			TimeManager.instance.SlowDown(); //calling the slowdown function if you aren't moving
		}
	}
}
