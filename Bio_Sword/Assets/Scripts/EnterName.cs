using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterName : MonoBehaviour {

    public KeyCode Enter; 
    public InputField name;
    public string levelToLoad; 

	void Update () {
        
        if(Input.GetKey(Enter)){

            PlayerPrefs.SetString("name", name.text);
            SceneManager.LoadScene(levelToLoad);

        }
	}
}
