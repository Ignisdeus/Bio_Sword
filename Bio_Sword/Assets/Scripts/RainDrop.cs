using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDrop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public Vector2 yScale; 
    public float speed; 
	void Update () {


        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < yScale.x) {

            transform.position = new Vector3(transform.position.x, yScale.y, transform.position.z);
        }

        }
}
