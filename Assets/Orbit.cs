using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	
	public Vector3 center = new Vector3(0, 0, 0);
	public Vector3 axis = new Vector3(1, 1, 1);
	public float angularSpeed = 180;
	

	// Update is called once per frame
	void Update () {
		transform.RotateAround(center, axis, angularSpeed * Time.deltaTime); 
	}
}
