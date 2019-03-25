using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Boss_Cont : MonoBehaviour {

	
	void Start () {
		GM = GameObject.FindGameObjectWithTag("GM"); 
	}
	GameObject GM; 
	bool iceGem = false;  
	void Update () {

        if(Input.GetKeyDown("e")){
            iceGem = !iceGem;

                    if(iceGem){
                         gameObject.GetComponent<Player>(). iceCast = true; 
                         gameObject.GetComponent<Player>(). fireCast = false; 
                         GM.SendMessage("ActiveGem", 1);

                    }else{
                         gameObject.GetComponent<Player>(). iceCast = false; 
                         gameObject.GetComponent<Player>(). fireCast = true; 
                        GM.SendMessage("ActiveGem", 2);

                    }


        }


        
        
		
	}
}
