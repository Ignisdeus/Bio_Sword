using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour {

	public float time; 
	void Start () {
		
        Invoke("DestroyGameObject", time);
	}

    private void DestroyGameObject() {

        Destroy(gameObject);
        
    }


}
