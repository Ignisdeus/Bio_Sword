using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyDeleter : MonoBehaviour {

    private void Start() {
        

        GameObject[] found = GameObject.FindGameObjectsWithTag("Audio");
        
        if(found.Length > 1){
            for( int i = 1 ; i < found.Length; i ++){
                Destroy(found[i]);
            }

        }
    }
}
