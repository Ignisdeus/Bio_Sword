using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<SpriteRenderer>().sprite = ghosts[0];
        audioS = GetComponent<AudioSource>(); 
	}
	AudioSource audioS;
    public AudioClip hitAudio, pluseAudio, explAudio; 
	public Vector2 patrole; 
    public float speed, attackRange;
    GameObject player;
    bool right = true; 
    public Sprite[] ghosts; 
    public int health =100; 
    float timer;
    public float timeBeforeAttack; 
    public GameObject explosion;
    public GameObject dieExpl; 
    bool flash = false;
    float flashMod = 0.5f;
	void Update () {

        float dist = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(dist);
        if( dist < attackRange){
            timer += Time.deltaTime;
            //if(timer % flashMod == 0){
            flash = !flash; 
            //flashMod-= 0.1f; 
            //}

            if(timer >timeBeforeAttack){
                //explode
                GameObject.FindGameObjectWithTag("GM").GetComponent<AudioSource>().PlayOneShot(explAudio, 1f);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }else{
            flash = false; 
            timer =0; 
            flashMod = 0.5f;
            if (transform.position.x <= patrole.x) {
                right = true;
            }

            if (transform.position.x >= patrole.y) {
                right = false;
            }

            if(right){
                transform.localRotation = Quaternion.Euler(0,0,0);
            }else{
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if(health <=0 ){
            Instantiate(dieExpl, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("GM").SendMessage("AddScore", 500);
            Destroy(gameObject); 
        }

        if (flash && !hit) {
            audioS.PlayOneShot(pluseAudio, .5f);
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }else if (!flash && !hit){
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        }

     void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Sword"){
            audioS.PlayOneShot(hitAudio, 1f);
            StartCoroutine(Hit());
            health -= (int)Random.Range(33,50);
        }
    }
    bool hit; 
    IEnumerator Hit() {
        
        hit = true; 
        GetComponent<BoxCollider2D>().enabled =false;
        GetComponent<SpriteRenderer>().sprite = ghosts[1];
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().sprite = ghosts[0];
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<BoxCollider2D>().enabled =true;
        hit = false; 
     

    }


 }
