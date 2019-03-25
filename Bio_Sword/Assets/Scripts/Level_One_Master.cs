using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_One_Master : MonoBehaviour {

	public Vector2 min, max; 
    public GameObject rainDrop;
    public int rainDropCount; 
     
	void Start () {
		
        
        Raining(rainDropCount);

	}
	
	
	void Update () {
		
	}

    void Raining(int x ) {

  
        for(int i =0; i < x ; i ++){
            Vector2 pos = new Vector2(Random.Range(min.x, max.x),Random.Range(min.y, max.y));
            Instantiate(rainDrop, pos, Quaternion.identity);
           // Raining(x--);
        }
    }
   public string levelToLoad; 
    
  IEnumerator LoadLevel(){

        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(levelToLoad);

  }

    public void LoadLevelButton() {
        StartCoroutine(LoadLevel());


    }
}
