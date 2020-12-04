using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //シーン切り替えに使用するライブラリ


public class FadePractice : MonoBehaviour
{
    public Fade fade;
    //float step_time;

    private void Update()
    {
        // Fadeおためし
        if (Input.GetKeyDown(KeyCode.I))
        {
            fade.FadeIn(1.3f, () => print("フェードイン完了"));
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            fade.FadeOut(1.3f, () => print("フェードアウト完了"));
        }

        /*
        // ミニゲーム1 へ遷移(仮)
        else if (Input.GetKeyDown("1"))
        {
            fade.FadeIn(1.0f, () => {
                print("フェードイン完了");
                // 経過時間をカウント
                step_time += Time.deltaTime;
                if (step_time >= 1.5f)
                {
                    SceneManager.LoadScene("TyouchinLightsOut");
                }
                fade.FadeOut(2.5f, () => print("ミニゲーム1 起動"));
            });
            
        }
        */
    }
}