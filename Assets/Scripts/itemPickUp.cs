using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usage: put this on any pick up objects
//intent: item will lerp to player and be visible in camera

public class itemPickUp : MonoBehaviour {
	
	//destination towards 
	public Vector3 destination;
	public GameObject player;
	public playerController playerObj;
	public float pickUpSpeed;
	
	// Use this for initialization
	void Start ()
	{
		destination =  new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerObj.itemHit == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, destination, pickUpSpeed * Time.deltaTime);
			Debug.DrawLine(transform.position, destination, Color.magenta);
			transform.LookAt(destination);
		}
	}
}
