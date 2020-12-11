using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour {
    
    public AudioClip chin;
    AudioSource audioSource;

    TimeManager timeManager;

    void Start() {
        audioSource = gameObject.GetComponent<AudioSource> ();
        // audioSource.clip = chin;
        timeManager = gameObject.AddComponent<TimeManager> ();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            audioSource.PlayOneShot(chin);
        }
	}
}