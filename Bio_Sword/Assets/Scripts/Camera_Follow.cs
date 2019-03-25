using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

	public GameObject player; 
	void Start () {
		

	}
	
	public Vector2 min, max;
    public float distanceOnZ; 
	void Update () {

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,distanceOnZ);

        if(transform.position.x < min.x){
            transform.position = new Vector3(min.x, transform.position.y,distanceOnZ);
        }
        if(transform.position.x > max.x){
            transform.position = new Vector3(max.x, transform.position.y,distanceOnZ);
        }
        if(transform.position.y < min.y){
            transform.position = new Vector3(transform.position.x, min.y,distanceOnZ);
        }
        if(transform.position.y > max.y){
            transform.position = new Vector3(transform.position.x, max.y,distanceOnZ);
        }
		
	}
}
