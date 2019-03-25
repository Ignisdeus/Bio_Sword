using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	
	public float rotationSpeed = 50f; 
	void Update () {
		transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
	}
}
