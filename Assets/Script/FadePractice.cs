using UnityEngine;
using System.Collections;

public class FadePractice : MonoBehaviour
{
    public Fade fade;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            fade.FadeIn(1.0f, () => print("フェードイン完了"));
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            fade.FadeOut(1.0f, () => print("フェードアウト完了"));
        }
    }
}