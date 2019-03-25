using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Cannons : MonoBehaviour {

	
	void Start () {
		
	}
	
    public Sprite iceSprite, fireSprite; 
    public int effect = 3; 
	void Update () {

        if (effect == 0) {
            gameObject.tag = "FireCannon";
            GetComponent<BoxCollider2D>().enabled = true; 
            firePart.SetActive(true); 
            icePart.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = fireSprite;
        }
        if (effect == 1) {
            gameObject.tag = "FireCannon";
            GetComponent<BoxCollider2D>().enabled = false; 
            firePart.SetActive(false); 
            icePart.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = fireSprite;
        }
        if( effect ==2 ){
            gameObject.tag = "IceCannon";
            GetComponent<BoxCollider2D>().enabled = false; 
            firePart.SetActive(false); 
            icePart.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = iceSprite;

        }

        if(effect == 3){
            gameObject.tag = "IceCannon";
            GetComponent<BoxCollider2D>().enabled = true; 
            firePart.SetActive(false); 
            icePart.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = iceSprite; 
        }


        }


    public GameObject firePart, icePart; 
    bool lit; 
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Fire"){
            if( effect > 0 ){
                effect --; 
            }
        }
        if(other.gameObject.tag == "Ice"){

            if( effect < 3 ){
                effect ++; 
            } 
        }

    }
}
