using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FungusMessenger : MonoBehaviour
{
    // 表示・非表示の対象
    public GameObject SetObj;
    // 上記用のフラグ
    public Boolean FlagActive = true;

    public Fungus.Flowchart flowchart = null;
    public string message = "";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (flowchart && collision.gameObject.tag == "Player")
        {
            flowchart.SendFungusMessage(message);
        }
    }

    void Update()
    {
        // FlagActiveがtrueならオブジェクト表示
        if (FlagActive)
        {
            SetObj.SetActive(true);
        } else
        {
            SetObj.SetActive(false);
        }
    }
}
