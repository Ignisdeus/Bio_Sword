using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_To_Destroy : MonoBehaviour {

    public int level = 1;
    public int maxLevel = 3;

    public void LevelUp (){
        level++; 

        if(level >= maxLevel){
           StartCoroutine(WaitTillDestroy());
        }
    }

    IEnumerator WaitTillDestroy(){

        yield return new WaitForSeconds(0.8f);
         Destroy(gameObject);

    }


}
