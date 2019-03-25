using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFlash : MonoBehaviour {

	
	void Start () {
		GameObject.FindGameObjectWithTag("GM").SendMessage("FlashInfo");
        Destroy(gameObject);
	}
	
	

}
