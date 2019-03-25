using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioSword_Pup : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player"){
            //GameObject.FindGameObjectWithTag("GM").SendMessage("AddScore",1000);
            GameObject.FindGameObjectWithTag("GM").SendMessage("EndOfGame");
            Destroy(gameObject);
        }
    }
}
