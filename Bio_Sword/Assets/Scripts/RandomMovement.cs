using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		dir = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f),0);
	}
	
	Vector3 dir;
    public float speed = 0.5f;
	void Update () {

        transform.Translate(dir * speed * Time.deltaTime); 

		
	}
}
