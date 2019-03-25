using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPad : MonoBehaviour {

    bool canTrigger= true;
    public GameObject GM;
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player" && canTrigger){
            canTrigger = false; 
            GM.SendMessage("LoadLevel");
            GameObject.FindGameObjectWithTag("GM").SendMessage("LevelUp");
            other.gameObject.SendMessage("LevelOver");
           


        }
    }
}
