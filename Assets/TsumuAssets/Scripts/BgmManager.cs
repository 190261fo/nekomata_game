using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {

    public AudioClip[] audios;
    private AudioSource audioSource;
    private int i;

    void Start() {
        audioSource = this.GetComponent<AudioSource> ();
        if(audios != null) {
            i = Random.Range(0,audios.Length);
        }
        audioSource.clip = audios[i];
        audioSource.Play();
    }

    void Update() {
        
    }
}
