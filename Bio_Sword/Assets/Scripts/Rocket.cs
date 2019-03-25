using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    public bool bossRocket= false; 
	public float speed, dest;
    public GameObject parts; 
    Vector3  pos; 
    AudioSource audioS;
   
	void Start () {
        if( bossRocket){
            pos = transform.position; 

        }
        audioS = GetComponent<AudioSource>();
		parts.SetActive(false);
	}
	
	public bool lit =false, canLight = true; 
	void Update () {
		
        if(lit ){
            parts.SetActive(true);
            audioS.Play();
            transform.Translate(Vector3.right * - speed * Time.deltaTime);
        }else{
            audioS.Stop();
        }
	}

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject);
        if(other.gameObject.tag == "dest" && canLight){

            parts.SetActive(false);
            if(!bossRocket){
            Destroy(gameObject.GetComponent<Rocket>());
            }else{
                canLight = false; 
                lit =false;
                StartCoroutine(Reset()); 
            }


        }
        
        if(other.gameObject.tag == "Fire" && !lit){
            Debug.Log("Fire Hit ME");
            lit = true; 

        }
        
    }

    IEnumerator Reset(){

        yield return new WaitForSeconds(2.5f);
        transform.position = pos;
        canLight = true; 

    }
}
