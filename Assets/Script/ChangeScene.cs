using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えに使用するライブラリ

public class ChangeScene : MonoBehaviour
{
    // 「はじめる」をクリック
    public void OnClickStartButton()
    {
        // 現実世界 へ遷移
        SceneManager.LoadScene("GenjitsuScene");
    }

    // 「つづきから」をクリック
    public void OnClickRoadButton()
    {
        // 異世界 へ遷移
        SceneManager.LoadScene("IsekaiScene");
    }

    // 「オプションアイコン」をクリック
    public void OnClickOptionButton()
    {
        // オプション画面 へ遷移
        SceneManager.LoadScene("SampleScene");
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
        else if (Input.GetKeyDown("3"))
        {
            // 「3」クリックで ミニゲーム3 へ遷移
            SceneManager.LoadScene("");
        }
        else if (Input.GetKeyDown("4"))
        {
            // 「4」クリックで 現実世界 へ遷移
            SceneManager.LoadScene("GenjitsuScene");
        }
        else if (Input.GetKeyDown("5"))
        {
            // 「5」クリックで 異世界 へ遷移
            SceneManager.LoadScene("IsekaiScene");
        }
    }
}
