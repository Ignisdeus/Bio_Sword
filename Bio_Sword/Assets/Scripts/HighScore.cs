using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    int playerScore; 
    string playerName; 
	public Text[] scores;
    public string[] names = new string[4];
    public int[] scoreValue = new int[4];
    public Text playerScoreT; 
	// Use this for initialization
	void Start () {      
        playerName = PlayerPrefs.GetString("name");

        
        for(int i = 0 ; i < scoreValue.Length; i ++){
            scoreValue[i] = PlayerPrefs.GetInt("Score" + i);
            names[i] = PlayerPrefs.GetString("Name" + i);
        }

        scoreValue[3] = PlayerPrefs.GetInt("PlayerScore");
        names[3] = PlayerPrefs.GetString("name");
        Debug.Log(PlayerPrefs.GetInt("PlayerScore"));
         
        
        for( int i =0; i < scoreValue.Length-1; i ++){
            for( int j =0 ; j < scoreValue.Length -1; j ++){
                if( scoreValue[j] < scoreValue[j+1]){
                    int temp = scoreValue[j];
                    scoreValue[j]= scoreValue[j+1];
                    scoreValue[j+1] = temp;
                    string tempS = names[j];
                    names[j]= names[j+1];
                    names[j+1] = tempS;
                    
                }
            }
        }
        

		for(int i = 0 ; i < scores.Length; i ++){
            scores[i].text = names[i] + " : "+  scoreValue[i];
        }

        for(int i = 0 ; i < scoreValue.Length; i ++){
            PlayerPrefs.SetInt("Score" + i ,  scoreValue[i]);
            PlayerPrefs.SetString("Name" + i ,  names[i]);
            //scoreValue[i] = PlayerPrefs.GetInt("Score" + i);
        }
         //playerScoreT.text ="Your Score = " + PlayerPrefs.GetInt("PlayerScore");
	}
 

}
