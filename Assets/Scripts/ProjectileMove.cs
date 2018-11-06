using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

	//This script handles the movement of the projectile

	//speed of projectile
	public float speed;

	//firing rate of prpjectiles (not relevant)
	public float fireRate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if the speed is higher than 0
		if (speed != 0)
		{
			//move the bullet forward
			transform.position += transform.forward * (speed * Time.deltaTime);
		}
		else
		{
			Debug.Log("No Speed");
		}
		
	}
	
	//none functioning collisions code
 /*
	void OnCollisionEnter(Collision co)
	{
		speed = 0;
		Destroy(gameObject);
	} */
}
