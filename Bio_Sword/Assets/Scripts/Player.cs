using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	
    public GameObject GraveStone; 
    public KeyCode jump, attack,cast;
    public GameObject sword,swordTrail;
    GameObject GM;
    public bool holdingSword = false, iceCast = false, fireCast= false; 
    Vector2 startingPos;
    public float maxFallDistance = -10f; 
    


    Animator anim; 
    AudioSource audioS; 
    public AudioClip land, swordSwing, portal, hit; 
	void Start () {
        audioS= GetComponent<AudioSource>();
        parts =GetComponentsInChildren<SpriteRenderer>();
        startingPos = transform.position; 
        sword.GetComponent<BoxCollider2D>().enabled = false;
        swordTrail.SetActive(false); 
		anim = GetComponent<Animator>();
       
        if(!holdingSword){
            sword.GetComponent<Renderer>().enabled = false;
        }else{
            sword.GetComponent<Renderer>().enabled = true;
        }
        GM = GameObject.FindGameObjectWithTag("GM");
        hp = GM.GetComponent<GameMaster>().hp * 100; 
	}
	
	public float speed = 10f, jumpForce;
    float horz,vert;
    bool right = true; 
    public GameObject stars;
    float pulseTimer;
    float hp = 100f; 
    
	void Update () {
        if (canMove){
        if(transform.position.y < maxFallDistance){
            transform.position = startingPos;
            GM.SendMessage("OnHit", 30);
            hp -= 30; 
            
        }
        
        horz = Input.GetAxis("Horizontal");
        
        
        if(!grounded){
            anim.SetInteger("Action", 2);
        }
        /*if( horz > 0.1f && grounded && !isAttacking && !casting){
            right = true; 
            anim.SetInteger("Action", 1);
            transform.localRotation = Quaternion.Euler(0,0,0);
            transform.Translate(Vector3.right * speed * (horz * Time.deltaTime));
        }else if( horz < -0.1f && grounded && !isAttacking && !casting){
            right = false; 
            anim.SetInteger("Action", 1);
            transform.localRotation = Quaternion.Euler(0,180,0);
            transform.Translate(Vector3.right * -speed * (horz * Time.deltaTime));
        }else if(grounded && !isAttacking && !casting){
             anim.SetInteger("Action", 0);
        }*/

        if( horz > 0.1f){
            right = true; 
        }
        if( horz < -0.1f){
            right = false;
        }
        if(right){
            transform.localRotation = Quaternion.Euler(0,0,0);
        }else{
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        if( Mathf.Abs(horz) > 0.1f && grounded){
            anim.SetInteger("Action", 1);
        }else if(grounded && !casting){
            anim.SetInteger("Action", 0);
        }

        if(!casting){
        transform.Translate(Vector3.right * speed * (Mathf.Abs(horz) * Time.deltaTime));
        }

        if( !isAttacking && Input.GetKeyDown(KeyCode.Space)  && holdingSword ){
            audioS.PlayOneShot(swordSwing,0.8f);
            anim.SetInteger("Action", 3); 
            StartCoroutine(SwordEffects());

        }
        if( Input.GetKey(cast) && grounded  && !isAttacking
            ||Input.GetKey(KeyCode.DownArrow) && grounded && !isAttacking){

            casting = true;     
            anim.SetInteger("Action", 4);

            if (iceCast) {
                pulseTimer += 1;

                if (pulseTimer % 30 == 0) {
                    Instantiate(iceCastRing, transform.position, Quaternion.identity);
                }
            }
            else if (fireCast) {
                 pulseTimer += 1;

                if (pulseTimer % 30 == 0) {
                    Instantiate(fireCastRing, transform.position, Quaternion.identity);
                }

            }

        }else{
            casting = false; 
        }      
        

        if(Input.GetKeyDown(jump)  && grounded|| Input.GetKeyDown(KeyCode.UpArrow) && grounded){
            grounded = false;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }
        }else{
            anim.SetInteger("Action", 0);
        }
        if (hp <= 0) {
            Instantiate(GraveStone, transform.position, Quaternion.identity);
            Destroy(gameObject); 

        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag == "Fire" || other.gameObject.tag == "FireCannon") {
            GM.SendMessage("OnHit", 10);
            hp -= 10; 
            StartCoroutine( Hit());

        }
        if (other.gameObject.tag == "Ice" || other.gameObject.tag == "IceCannon") {
            GM.SendMessage("OnHit", 10);
            hp -= 10;
            StartCoroutine( Hit());

        }


        }

    bool grounded = true,casting = false;
    bool isAttacking;
    //private void OnTriggerEnter2D(Collider2D other) {


  
    //}


    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "rocket"){
            grounded = true;

        }
        if(other.gameObject.tag == "Platfrom"){
            grounded = true;

        }
        if(other.gameObject.tag == "rocket"){

            transform.SetParent(other.gameObject.transform);
        }

        if(other.gameObject.tag == "Sword"){
            holdingSword = true; 
            GM.SendMessage("AddScore", 100);
            sword.GetComponent<Renderer>().enabled = true; 
            Instantiate(stars, gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            StartCoroutine(SlowDownTime(0.1f));
          
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "rocket"){

            transform.SetParent(null);
        }
    }

    public string epx;
    public GameObject icePup, iceCastRing, fireCastRing;
    
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == epx){
            GM.SendMessage("OnHit", 10);
            //audioS.PlayOneShot(hit, 1f);
            hp -= 10;
            StartCoroutine(Hit());
            StartCoroutine(SlowDownTime(0.1f));
        }
        if(other.gameObject.tag == "Boss_C"){
            Destroy(other.gameObject);
            //audioS.PlayOneShot(hit, 1f);
            GM.SendMessage("OnHit", 5);
            hp -= 5;
            StartCoroutine(Hit());
            StartCoroutine(SlowDownTime(0.1f));
        }
        if(other.gameObject.tag == "Ground" && !grounded){
            audioS.PlayOneShot(land, 1f);

        }
        if(other.gameObject.tag == "Platfrom"){
            audioS.PlayOneShot(portal, 1f);

        }

     
        if(other.gameObject.tag == "Ice"){
            iceCast = true;
            fireCast = false;
            GM.SendMessage("AddScore", 50);
            GM.GetComponent<GameMaster>().ActiveGem(1);
            Instantiate(stars, transform.position, Quaternion.identity);
            StartCoroutine(SlowDownTime(0.1f));
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Fire_G"){
            iceCast = false;
            fireCast = true;
            GM.SendMessage("AddScore", 50);
            GM.GetComponent<GameMaster>().ActiveGem(2);
            Instantiate(stars, transform.position, Quaternion.identity);
            StartCoroutine(SlowDownTime(0.1f));
            Destroy(other.gameObject);
        }

    }



 


    IEnumerator SwordEffects(){
        yield return new WaitForSeconds(0.1f);
        gameObject.tag = "Sword";
        isAttacking = true;
        swordTrail.SetActive(true);
        sword.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        swordTrail.SetActive(false);
        sword.GetComponent<BoxCollider2D>().enabled = false;
        isAttacking = false;
        gameObject.tag = "Player";

    }

    public IEnumerator SlowDownTime(float time){
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(time);
        Time.timeScale = 1f;

    }
    SpriteRenderer[] parts;
    IEnumerator Hit() {

        
        audioS.PlayOneShot(hit, 1f);
        for( int i =0; i < parts.Length; i ++){
            parts[i].color = Color.red;
        }

        yield return new WaitForSeconds(0.1f);
        for( int i =0; i < parts.Length; i ++){
            parts[i].color = Color.white;
        }  
    }
    bool canMove= true; 
    void LevelOver(){
        StartCoroutine(Fade());
        canMove = false; 
    }
    float fadeValue= 1f; 
    IEnumerator Fade(){
        if( fadeValue > 0f){
            fadeValue -= 0.15f;
            yield return new WaitForSeconds(0.05f);
            for( int i =0; i < parts.Length; i ++){
                parts[i].color = new Color(255,225,255,fadeValue);
            }
                StartCoroutine(Fade());
        }else{

           // GM.SendMessage("AddScore", 1000);
        }

    }

}
