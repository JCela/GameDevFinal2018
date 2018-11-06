using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{


	//public float Delta;

	//public float FixedDelta;

	//public float TimeScale = 1;

	public float slowDownFactor = 0.5f; //sets variable for on a scale from 0=>1, how slow do we go? 

	//public float slowdownLength;

	public static TimeManager instance; //making this manager a static instance
	// Use this for initialization
	 void Start()
	{
		instance = this; //setting the static instance
	}

	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown(KeyCode.P))
		{
		//	if (Time.timeScale == 1.0f)

			//TimeScale = 0.5f; 
			
			//else
			
			//	Time.timeScale = 1.0f; 
			
		SlowDown();
			
			//Time.fixedDeltaTime = 0.02f * Time.timeScale; 
		}
		*/
		
		

		//Delta = Time.deltaTime * TimeScale;
	}

	public void SlowDown() //a function to call when you want something to slow down
	{
		Time.timeScale = slowDownFactor; //set the time scale = to the slowdownfactor
		Debug.Log("TimeMan"); //debugging to be sure it's reading it
	}

	
}
