using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public Vector3 targetScale;
    public float speed; 
	void Update () {
		
         transform.localScale = Vector3.Lerp (transform.localScale, targetScale, speed * Time.deltaTime);

	}
}
