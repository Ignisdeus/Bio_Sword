using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_pup : MonoBehaviour {

    public float speed = 180f; 
    private void Update() {
        
        transform.Rotate(Vector3.up * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player"){

            GameObject.FindGameObjectWithTag("GM").SendMessage("AddScore", 10);
            Destroy(gameObject); 
        }
        
    }
}
