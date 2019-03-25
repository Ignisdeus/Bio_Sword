using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Wave : MonoBehaviour {



    float amount = 30; 
    private void OnTriggerEnter2D(Collider2D other) {
        
        //Debug.Log("Testing");
        if(other.gameObject.tag == "Ice_B"){
            amount = other.gameObject.GetComponent<SpriteRenderer>().color.a;
            amount += 0.1f; 
           
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255, amount);
            if(other.gameObject.GetComponent<SpriteRenderer>().color.a >= 1f ){
                
                other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                other.gameObject.tag ="Ground";
                ParticleSystem[] parts = other.gameObject.GetComponentsInChildren<ParticleSystem>();

                for(int i =0; i < parts.Length; i ++){
                     parts[i].enableEmission = true;
                }
            }else if(other.gameObject.GetComponent<SpriteRenderer>().color.a < 1f ){
                GameObject.FindGameObjectWithTag("GM").SendMessage("AddScore", 10);

            }


        }
    }
}
