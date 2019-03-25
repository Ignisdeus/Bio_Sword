using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Particals : MonoBehaviour {

	public float emittionSpeed; 
	void Start () {
		InvokeRepeating("Emmit", 0f, emittionSpeed);
	}
	
	public GameObject partical;
     
    void Emmit(){

        Instantiate(partical, transform.position, Quaternion.identity); 

    }
}
