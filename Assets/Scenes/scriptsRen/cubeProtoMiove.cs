using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeProtoMiove : MonoBehaviour
{


	public float CubeSpeed = 0.5f; 
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0.2f * CubeSpeed, 0f,0f);
			TimeManager.instance.SlowDown();
		}

		else
		{
			Time.timeScale = 1;
		}
	}
}
