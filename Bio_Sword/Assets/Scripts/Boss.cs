using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	Animator anim; 
    public GameObject bridge;
    bool canAnim = true; 
	void Start () {

		parts = GetComponentsInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
	}
	
	int health = 200;
    GameObject player; 
    [Range(0.5f, 10f)]
    public float idelRange, attackRange, attackRate, speed;
    [Range(1, 5)]
    public int attackCount;
    float timer = 0; 
    public GameObject expl, smoke;
    public Vector2 range; 
    AudioSource audioS; 
    public AudioClip hit, death; 
	void Update (){	

        if( health <=0 ){
            
            bool dir = false;
            bridge.SendMessage("Down");
            for(int i = 0; i < 5 ; i ++){
                if (dir){
                dir = !dir; 
                Vector3 pos = new Vector3(transform.position.x + i, transform.position.y,transform.position.z);
                Instantiate(smoke, pos, Quaternion.identity);
                }else{
                dir = !dir;
                Vector3 pos = new Vector3(transform.position.x - i , transform.position.y,transform.position.z);
                Instantiate(smoke, pos, Quaternion.identity);
                }
            }
            GameObject.FindGameObjectWithTag("GM").SendMessage("AddScore", 3000);
             GameObject.FindGameObjectWithTag("GM").GetComponent<AudioSource>().PlayOneShot(death, 1f);
            Destroy(gameObject);

        }
        
        float dist = Vector3.Distance(player.transform.position, transform.position);

        if( dist > idelRange){
            // anim.SetInteger("Action", 1);
        }else if(player.transform.position.x < transform.position.x -1 && dist < idelRange){
            //anim.SetInteger("Action", 1);
            transform.Translate(Vector2.right * -speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0,0,0);
        }else if(player.transform.position.x > transform.position.x +1 && dist < idelRange){
            //anim.SetInteger("Action", 1);
            transform.Translate(Vector2.right * -speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0,180,0);
        }

       // timer += Time.deltaTime; 

        if(  dist < attackRange){
            timer += Time.deltaTime;
            if(timer > attackRate - 0.8f && canAnim){
                canAnim = false; 
                anim.SetInteger("Action", 2);
            }else {
                 anim.SetInteger("Action", 0);

            }
            if( timer > attackRate){
                canAnim = true; 
                timer = 0; 
                //StartCoroutine(AttackCoolDown());
                 for (int i =0; i < attackCount; i ++){
                    if(player.transform.position.x < transform.position.x ){
                    Vector3 pos = new Vector3(transform.position.x - 2 - i, transform.position.y,transform.position.z);
                    Instantiate(expl, pos, Quaternion.identity);
                    }else{
                    Vector3 pos = new Vector3(transform.position.x + 2 + i, transform.position.y,transform.position.z);
                    Instantiate(expl, pos, Quaternion.identity);

                    }
                }
            }


        }

        if( transform.position.x < range.x){
            transform.position = new Vector3(range.x,transform.position.y,transform.position.z );
        }
        if(transform.position.x > range.y){
            transform.position = new Vector3(range.y,transform.position.y,transform.position.z );
        }


	}

    SpriteRenderer[] parts;
    bool canBeHurt = true;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "FireCannon") {
            canBeHurt = false;
            StartCoroutine(Hit(1, other.gameObject));
            health -= 50;
            //other.gameObject.GetComponent<Boss_Cannons>().effect ++; 

        }

        if(other.gameObject.tag == "IceCannon"){
            canBeHurt = false;
            StartCoroutine(Hit(-1, other.gameObject));
            health -= 50; 
            //other.gameObject.GetComponent<Boss_Cannons>().effect --; 
        }
    }

    IEnumerator Hit(int x, GameObject other){
        anim.SetInteger("Action", 1);
        audioS.PlayOneShot(hit, 1f);
        for(int i =0; i < parts.Length; i ++){
            parts[i].color = Color.red;
        }
        other.gameObject.GetComponent<Boss_Cannons>().effect += x; 
        yield return new WaitForSeconds(0.5f);
        for(int i =0; i < parts.Length; i ++){
            parts[i].color = Color.white;
            canBeHurt = true; 
        }
        anim.SetInteger("Action", 0);
       
    }

}
