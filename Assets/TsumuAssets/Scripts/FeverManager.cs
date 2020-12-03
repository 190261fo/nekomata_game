using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverManager : MonoBehaviour {
	Text feverTimeText;
	private float nextTime;
    public float interval = 0.3f; // 点滅周期
	Scrollbar scrollbar;
	float feverValue = 0;
	bool isFever = false;

	Action onFeverStartCallBack;

	void Start () {
		GameObject canvas = GameObject.Find ("Canvas");
		nextTime = Time.time;
		if (canvas != null) {
			Transform feverGUI = canvas.transform.Find ("FeverGUI");
			Transform feverTime = canvas.transform.Find("FeverTime");
			if (feverGUI != null) {
				scrollbar = feverGUI.GetComponent<Scrollbar> ();
			}
			if (feverTime != null)
			{
				feverTimeText = feverTime.GetComponent<Text>();
			}
		}
	}

	void Update () {
		if (!isFever) {
			feverValue -= Time.deltaTime * 2; // takes 50 sec to go from full to empty
			if (feverValue < 0) {
				feverValue = 0;
			}
		} else {
			feverValue -= Time.deltaTime * 10; // takes 10 sec to go from full to empty
			if (feverValue < 0) {
				feverValue = 0;
				OnFeverEnd ();
			}
		}

		if (Time.time > nextTime) {
            float alpha = feverTimeText.GetComponent<CanvasRenderer>().GetAlpha();
            if (alpha == 1.0f) {
                feverTimeText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			} else {
                feverTimeText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
			}
            nextTime += interval;
        }

		SyncFeverGUI ();
	}

	public void RegisterOnFeverCallBack(Action onFeverCallBack) {
		this.onFeverStartCallBack = onFeverCallBack;
	}

	public void AddFeverValue(int chain) {
		if (!isFever) {
			feverValue += 3.4f * (float)chain; 
			if (feverValue > 100) {
				feverValue = 100;
				OnFeverStart ();
			}
		}
	}

	public bool IsFever() {
		return isFever;
	}

	void OnFeverStart() {
		isFever = true;
		SyncFeverTime();
		SyncFeverTime ();
		if (onFeverStartCallBack != null) {
			onFeverStartCallBack ();
		}
	}

	void OnFeverEnd() {
		isFever = false;
		feverTimeText.text = "";
	}

	void SyncFeverGUI() {
		if (scrollbar != null) {
			scrollbar.size = feverValue / 100f;
		}
	}

	void SyncFeverTime() {
		if (feverTimeText != null)
		{
			feverTimeText.text = "フィーバータイム！";
		}
	}
}
