﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン切り替えに使用するライブラリ

public class Change_tyouchin : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("TyouchinLightsOut");
    }
}
