using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

	// Use this for initialization
	void Down () {

        InvokeRepeating("OpenProccess", 0.1f,0.1f);
		
	}
	public float speed;
    void OpenProccess(){

        if (transform.rotation.z < 0) {
            
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
            //yield return new WaitForSeconds(0.1f);
            //Open();
        }else{
            Destroy(gameObject.GetComponent<Bridge>());
        }

        }
}
