using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Cannon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        myBox = GetComponent<BoxCollider2D>();
	}
	
	BoxCollider2D myBox; 
    public GameObject[] particals;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Fire"){

            myBox.enabled=false;
            for (int i = 0; i < particals.Length; i++) {
                Destroy(particals[i]);
                GameObject.FindGameObjectWithTag("GM").SendMessage("AddScore", 30);
                Destroy(gameObject.GetComponent<Fire_Cannon>());
            }

            }
    }
}
