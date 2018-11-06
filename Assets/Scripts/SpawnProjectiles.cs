using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour {

	
    public GameObject firePoint;
	public List<GameObject> vfx = new List<GameObject>();
	public RotateToMouse RotateToMouse;

	private GameObject effectToSpawn;
	private float timeToFire = 0;

	// Use this for initialization
	void Start ()
	{
		effectToSpawn = vfx[0];
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButton(0) && Time.time >= timeToFire)
		{
			// spawns the bullet
			timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
			SpawnVFX();
		}
		
	}

	void SpawnVFX()
	{
		GameObject vfx;

		//if the firepoint exists
		if (firePoint != null)
		{
			//instantiate a bullet
			vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
			if (RotateToMouse != null)
			{
				//bullet rotation equal to where circle is looking
				vfx.transform.localRotation = RotateToMouse.GetRotation();
			}
		}

		else
		{
			Debug.Log("no firepoint");
		}
	}
}
