using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public GameObject canvis;
    public Text pop; 
	void Start () {

		DontDestroyOnLoad(gameObject);
        score = 0;  
        gameOver.text = ""; 
        audioS =GetComponent<AudioSource>();
        

         
	}
	
	
    public Image health, fade;
    public float hp=1f;
    public Text scoreText, gameOver;
    float fadeAmount = 0 ; 
    
    int score; 
    char[] gameOverList= {'G','A','M','E', ' ','O','V','E','R'};
    int charCount=0; 
    float timeCount =0;
    
    
	void Update () {

        health.fillAmount = hp;
        scoreText.text = score.ToString();

        if (hp <= 0) {
            timeCount += Time.deltaTime; 
            if(fadeAmount <=1f){
               fadeAmount+=0.01f;
            }else{
                if( charCount < gameOverList.Length && timeCount > 0.2f){
                    timeCount =0; 
                    gameOver.text += gameOverList[charCount];
                    charCount++; 
                }else if (charCount >= gameOverList.Length && timeCount > 1.5f) {
                    EndOfGame();

                }
            }
            fade.color = new Color (0,0,0,fadeAmount); 
            

        }

        }

    void OnHit(int hpToLose) {

        while (hpToLose > 0) {

            hp-= 0.01f;
            hpToLose--; 
        }


    }

    public Text infoFlash; 
    public IEnumerator FlashInfo(){
        infoFlash.enabled = true; 
        yield return new WaitForSeconds(10f);
        infoFlash.enabled = false; 
    }
    AudioSource audioS; 
    public AudioClip scorePlus;
    bool canReset = true;

    void AddScore(int x){
        audioS.PlayOneShot(scorePlus, 1f);
        audioS.pitch += 0.1f;
        if(canReset){
            canReset = false; 
        StartCoroutine( ResetPitch());
        }
        Text pops = Instantiate(pop, canvis.transform.position, Quaternion.identity);
        pops.transform.SetParent(canvis.transform);
        pops.text = "+ " + x.ToString();
        StartCoroutine(ScoreAdd(x));

        
         
    }

    IEnumerator ScoreAdd(int x){

        yield return new WaitForSeconds(1f);
        score += x;


    }
    //public Image gem;
    public Image[] gems;
    public void ActiveGem(int x){

        switch(x){

         case 1:

                for(int i =0; i < gems.Length; i ++){
                    gems[i].enabled = false; 
                }
                gems[1].enabled = true; 
                break;


         case 2:

                for(int i =0; i < gems.Length; i ++){
                    gems[i].enabled = false; 
                }
                gems[2].enabled = true; 
                break;

         default:

                for(int i =0; i < gems.Length; i ++){
                    gems[i].enabled = false; 
                }
                gems[0].enabled = true; 
                break;
        }


    }
    public string levelToLoad;
    
    void HpConvert(){




       

    }
    void EndOfGame() {
        int held = (int)Mathf.Floor(hp * 100);
        Debug.Log(held);
        int scoreToAdd = 0; 
       for(int i = 0; i < held ; i ++){
            
           scoreToAdd += 25;
       }
        
       AddScore(scoreToAdd);
       StartCoroutine(WaitForGameOver());


    }

    IEnumerator WaitForGameOver(){

        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetInt("PlayerScore", score);
        SceneManager.LoadScene(levelToLoad);
        Destroy(gameObject);
    }

    IEnumerator ResetPitch(){

        yield return new WaitForSeconds(5f);
        audioS.pitch = 1f;
        canReset = true; 

        }


    }
