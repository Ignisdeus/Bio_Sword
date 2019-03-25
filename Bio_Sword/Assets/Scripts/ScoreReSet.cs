using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 for(int i = 0 ; i < 3; i ++){
            PlayerPrefs.SetInt("Score" + i , (i+1) * 100);
            PlayerPrefs.SetString("Name" + i , "Bob");
        }

         PlayerPrefs.SetInt("PlayerScore", 0);
	}
	

}
