using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public Sprite[] walls; 
    public int health = 100; 
	void Update () {

        if( health > 66){
            GetComponent<SpriteRenderer>().sprite = walls[2];
        }else if(health > 33){
            GetComponent<SpriteRenderer>().sprite = walls[1];
        }else if (health > 0){
            GetComponent<SpriteRenderer>().sprite = walls[0];
        }else{
            GameObject.FindGameObjectWithTag("GM").SendMessage("AddScore", 100);
            Destroy(gameObject);
        }
	}

   
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Sword"){
            StartCoroutine(Hit());
            health -= (int)Random.Range(33,50);
        }
    }

        IEnumerator Hit() {
        GetComponent<SpriteRenderer>().color = Color.red;
 
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
