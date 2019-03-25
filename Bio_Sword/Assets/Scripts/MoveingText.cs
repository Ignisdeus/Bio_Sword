using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingText : MonoBehaviour {

	
	void Start () {
		
	}
	
	public float speed;
	void Update () {

        transform.Translate(Vector3.up * speed * Time.deltaTime);
		
	}
}
