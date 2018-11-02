using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{


	//public float Delta;

	//public float FixedDelta;

	//public float TimeScale = 1;

	public float slowDownFactor = 0.5f;

	public float slowdownLength;

	public static TimeManager instance; 
	// Use this for initialization
	 void Start()
	{
		instance = this; 
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

	public void SlowDown()
	{
		Time.timeScale = slowDownFactor;
		Debug.Log("TimeMan");
	}

	
}
