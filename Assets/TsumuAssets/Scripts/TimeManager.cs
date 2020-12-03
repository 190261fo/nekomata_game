using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	Text timeText;
	Text finishText;
	Text resultText;
	public float time;
	public Boolean FlagTimeStart = false;

	public AudioClip resultSE;
    AudioSource audioSource;

    ScoreManager scoreManager;

	public void Start() {
		audioSource = gameObject.GetComponent<AudioSource> ();
		scoreManager = gameObject.AddComponent<ScoreManager> ();
		GameObject canvas = GameObject.Find ("Canvas");
		if (FlagTimeStart) {
			if (canvas != null) {
				// 制限時間
				time = 60;
				Transform timeGUI = canvas.transform.Find ("TimeGUI");
				Transform finishGUI = canvas.transform.Find ("FinishGUI");
				Transform resultGUI = canvas.transform.Find ("ResultGUI");
				if (timeGUI != null) {
					timeText = timeGUI.GetComponent<Text> ();
					SyncTimeGUI ();
				}
				if (finishGUI != null) {
					finishText = finishGUI.GetComponent<Text> ();
				}
				if (resultGUI != null) {
        			resultText = resultGUI.GetComponent<Text> ();
      			}
			}
		}
	}

	void Update() {
		time -= Time.deltaTime;
		if (time < 0) {
			time = 0;
			SyncfinishGUI ();
			SyncResultGUI ();
			// audioSource.PlayOneShot(resultSE);
		}
		SyncTimeGUI ();
	}

	public void AddTime(float deltaTime) {
		time += deltaTime;
	}

	void SyncTimeGUI() {
		if (timeText != null) {
			timeText.text = "残り" + ((int)time).ToString () + "秒";
		}
	}

	void SyncfinishGUI() {
		if (finishText != null) {
			finishText.text = "そこまで！！";
		}
	}

	public void SyncResultGUI() {
  		if (resultText != null) {
    		if (int.Parse(scoreManager.scoreText.text) >= 150000){
      			resultText.text = "クリアSSS"; 
    		} else if (int.Parse(scoreManager.scoreText.text) >= 100000){
      			resultText.text = "クリアS";
    		} else if (int.Parse(scoreManager.scoreText.text) >= 80000){
      			resultText.text = "クリアA";
    		} else {
      			resultText.text = "クリア失敗";
			}
    	}
  	}

}
