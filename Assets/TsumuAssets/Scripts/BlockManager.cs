using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockManager: MonoBehaviour {

	public GameObject blockPrefab;
	public GameObject bombPrefab;
	public AudioClip startSE;
	public AudioClip blockSE;
	public AudioClip bombGenSE;
	// public AudioClip bombSE;

	GameObject firstBlock;
	GameObject lastBlock;
	List<GameObject> removeBlockList = new List<GameObject> ();

	AudioSource audioSource;

	ScoreManager scoreManager;
	FeverManager feverManager;
	TimeManager timeManager;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		StartCoroutine (GenerateBlocks (60));
		scoreManager = gameObject.AddComponent<ScoreManager> ();
		feverManager = gameObject.AddComponent<FeverManager> ();
		timeManager = gameObject.AddComponent<TimeManager> ();
		feverManager.RegisterOnFeverCallBack (() => timeManager.AddTime(5));
	}

	void Update () {
		if (Input.GetMouseButton (0) && firstBlock == null) {
			OnDragStart ();
		} else if (Input.GetMouseButton (0) && firstBlock) {
			OnDragging ();
		} else if (Input.GetMouseButtonUp (0) && firstBlock) {
			OnDragEnd ();
		}
	}        

	public void TimeStart() {
		audioSource.PlayOneShot(startSE);
		timeManager.FlagTimeStart = true;
		timeManager.Start();
	}

	IEnumerator GenerateBlocks(int n){
		for (int i = 0; i < n; i++) {
			yield return new WaitForSeconds (0.01f);
			GameObject block = GameObject.Instantiate (blockPrefab);
			block.transform.parent = transform;
		}
	}

	void GenerateBomb(Vector3 position) {
		GameObject bomb = GameObject.Instantiate (bombPrefab);
		bomb.transform.position = position;
		bomb.transform.parent = transform;
	}

	void OnDragStart() {
		if (timeManager.time != 0) {
			GameObject newBlock = MousedOverBlock();
			if (newBlock != null) {
				firstBlock = newBlock;
				lastBlock = newBlock;
				AddToRemoveBlockList(newBlock);
			}
		}
		
	}

	void OnDragging() {
		GameObject newBlock = MousedOverBlock ();
		if (newBlock != null && newBlock != lastBlock) {
			if (IsNewBlockRemovable (newBlock)) {
				lastBlock = newBlock;
				AddToRemoveBlockList (newBlock);
			}
		}
	}

	void OnDragEnd() {
		int count = removeBlockList.Count;
		if (count >= 3) {
			OnBlockClear(count);
			audioSource.PlayOneShot(blockSE);
			// 6個以上でボム生成
			if (count >= 6) { 
				GenerateBomb (lastBlock.transform.position);
				audioSource.PlayOneShot(bombGenSE);
			}
			ClearRemoveBlockList ();
		} else {
			ResetRemoveBlockList ();
		}
		firstBlock = null;
		lastBlock  = null;
	}

	GameObject MousedOverBlock() {
		RaycastHit2D hit = Physics2D.Raycast (
			                   Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

		if (hit.collider != null) {
			GameObject hitObject = hit.collider.gameObject;
			if (Block.IsBlock (hitObject)) {
				return hitObject;
			}
		}
		return null;
	}

	bool IsNewBlockRemovable(GameObject newBlock) {
		if (!Block.IsSameType (newBlock, firstBlock)) {
			return false;
		} else if (newBlock.GetComponent<Block> ().IsOnChain ()) {
			return false;
		}

		RaycastHit2D[] hits = Physics2D.RaycastAll (
			                      (Vector2)lastBlock.transform.position,
			                      (Vector2)(newBlock.transform.position - lastBlock.transform.position),
			                      1);

		if (hits.Length > 1) {
			if (hits [1].collider != null) {
				if (hits [1].collider.gameObject == newBlock.gameObject) {
					return true;
				}
			}
		}
		return false;
	}

	void AddToRemoveBlockList(GameObject block) {
		removeBlockList.Add (block);
		block.GetComponent<Block> ().SetIsOnChain (true);
		block.GetComponent<Block> ().SetTransparency (0.5f);
	}

	void ClearRemoveBlockList() {
		foreach (GameObject block in removeBlockList) {
			Destroy (block);
		}
		removeBlockList.Clear ();
	}

	void ResetRemoveBlockList() {
		foreach (GameObject block in removeBlockList) {
			block.GetComponent<Block> ().SetIsOnChain (false);
			block.GetComponent<Block> ().SetTransparency (1f);
		}
		removeBlockList.Clear ();
	}

	public void OnBlockClear(int chain) {
		scoreManager.AddScore (ScoreManager.CalculateScore (chain, 1, feverManager.IsFever()));
		feverManager.AddFeverValue (chain);
		StartCoroutine (GenerateBlocks (chain));
	}
}