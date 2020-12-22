using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeManager : MonoBehaviour {
    
    AudioSource audioSource;

    void Start() {
        audioSource = gameObject.GetComponent<AudioSource> ();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            AudioManager.GetInstance().PlaySound(0);
        }
	}
}