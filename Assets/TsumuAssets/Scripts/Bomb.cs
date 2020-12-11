using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour {

	public AudioClip bombSE;
	AudioSource audioSource;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();

	}

	void Update () {

	}
	
	void OnMouseDown() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 1f);
		GetComponentInParent<BlockManager> ().OnBlockClear (colliders.Length);

		foreach (Collider2D collider in colliders) {
			if (Block.IsBlock(collider.gameObject)) {
				audioSource.PlayOneShot(bombSE);
				Destroy (collider.gameObject);
			}
		}
		Destroy (gameObject);
	}
}
