using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public GameObject player, swordSwipe, hitPoint;
    public GameObject wallParts; 
    public float force; 
    AudioSource audioS;
    public AudioClip hitWall; 

    private void Start() {
        audioS = GetComponentInParent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag != "Ground" && other.gameObject.tag != "Boss"){
             player.tag = "Player";
            Instantiate(swordSwipe, hitPoint.transform.position, Quaternion.identity);
            player.GetComponent<Player>().SlowDownTime(0.05f); 
           
            if(other.gameObject.tag =="Wall"){
                audioS.PlayOneShot(hitWall, 1f);
                for(int i = 0; i < 4; i ++){

                    GameObject brick = Instantiate(wallParts, hitPoint.transform.position, Quaternion.Euler(0,0, Random.Range(0,180)));
                    Vector2 newPos = new Vector2 (Random.Range(-1,1), Random.Range(-1,1));
                    brick.GetComponent<Rigidbody2D>().AddForce(newPos * force);
                }


            }
            


        }


    }
}
