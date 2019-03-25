using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAudio : MonoBehaviour {

    AudioSource audioS; 
    public AudioClip clipToPlay;
    [Range(0f,1f)]
    public float volumeOfClip; 
    private void OnCollisionEnter2D(Collision2D other) {

        if (audioS == null){
        audioS = gameObject.AddComponent<AudioSource>();
        }

        audioS.PlayOneShot(clipToPlay, volumeOfClip);

    }
}
