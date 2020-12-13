using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えに使用するライブラリ
using System;

public class ChangeScene : MonoBehaviour
{
    public Fade fade;
    // public Boolean FadeStart = true;
    // public Boolean Flag_RorateGame = false;
    float time = 1.3f; // フェードイン・アウト時間

    // StartFadeにチェック有の場合
	void Start () {
        fade.FadeOut(time);
    }

    // 現実世界 へ遷移
    public void ChangeGenjitsu()
    {
        LoadLevel ("GenjitsuScene");
    }

    // 異世界 へ遷移
    public void ChangeIsekai()
    {
        LoadLevel ("IsekaiScene");
    }

    // オプション画面 へ遷移
    public void ChangeOption()
    {
        LoadLevel ("OptionScene");
    }

    // メニュー画面 へ遷移
    public void ChangeMenu()
    {
        LoadLevel ("MenuScene");
    }

    // タイトル画面 へ遷移
    public void ChangeTitle()
    {
        LoadLevel ("TitleScene");
    }

    // ミニゲーム1 へ遷移
    public void ChangeMinigame1()
    {
        LoadLevel ("TyouchinLightsOut");
    }

    // ミニゲーム へ遷移
    public void ChangeMinigame2()
    {
        LoadLevel ("Tsumu");
    }

    // ミニゲーム3 へ遷移
    public void ChangeMinigame3()
    {
        LoadLevel ("RoratePuzzle");
    }

    void LoadLevel (string name)
	{
		// フェードイン
		fade.FadeIn(time, () =>
		{
			// フェードイン完了後の処理（画面は真っ暗）
			Application.LoadLevel(name); //　シーン遷移
		});
	}

    void Update()
    {
        //　とりあえず の 切り替えボタン
        if (Input.GetKeyDown("1"))
        {
            // 「1」クリックで ミニゲーム1へ遷移
            SceneManager.LoadScene("TyouchinLightsOut");
        }
        else if (Input.GetKeyDown("2"))
        {
            // 「2」クリックで ミニゲーム2 へ遷移
            SceneManager.LoadScene("Tsumu");
        }
        // else if (Flag_RorateGame)
        // {
        //     // 「3」クリックで ミニゲーム3 へ遷移
        //     SceneManager.LoadScene("RoratePuzzle");
        // }
        else if (Input.GetKeyDown("3"))
        {
            // 「3」クリックで ミニゲーム3 へ遷移
            SceneManager.LoadScene("RoratePuzzle");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            // 「G」クリックで 現実世界 へ遷移
            SceneManager.LoadScene("GenjitsuScene");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            // 「I」クリックで 異世界 へ遷移
            SceneManager.LoadScene("IsekaiScene");
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            // 「T」クリックで 異世界 へ遷移
            SceneManager.LoadScene("TitleScene");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            // 「O」クリックで 異世界 へ遷移
            SceneManager.LoadScene("OptionScene");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            // 「M」クリックで 異世界 へ遷移
            SceneManager.LoadScene("MenuScene");
        }
    }
}
