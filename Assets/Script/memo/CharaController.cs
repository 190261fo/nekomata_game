using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityStandardAssets.Characters.ThirdPerson;
public class CharaController : MonoBehaviour
{
    GameObject playerObj;
    NekomataController player;
    void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<NekomataController>();
    }
    public void ActivatePlayer()
    {
        player.animator.enabled = true;
    }
    public void DeactivatePlayer()
    {
        player.animator.enabled = false;
        player.Stop();
    }
//   プレイヤーの移動禁止・許可スクリプトの作成
//   書けたら空のゲームオブジェクト（名前はPlayerControllerにしておきます）にアタッチ
}