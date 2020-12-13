using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityStandardAssets.Characters.ThirdPerson;
using Fungus;
using System;
[RequireComponent(typeof(Flowchart))]
public class NcpController : MonoBehaviour
{
  [SerializeField]
  string message = "";
  bool isTalking = false;
  GameObject playerObj;
  // ThirdPersonCharacter player;
  // ThirdPersonUserControl control;
  Flowchart flowChart;
     void Start()
    {
    playerObj = GameObject.FindGameObjectWithTag("Player");
    // player = playerObj.GetComponent<ThirdPersonCharacter>();
    // control = playerObj.GetComponent<ThirdPersonUserControl>();
    flowChart = GetComponent<Flowchart>();
    }
  void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.CompareTag("Player"))
    {
      // StartCoroutine(Talk());
    }
  }
  // IEnumerator Talk()
  // {
    // if (isTalking)
    // {
    //   yield break;
    // }
    // isTalking = true;
    // control.enabled = false;
    // player.Stop();
    // flowChart.SendFungusMessage(message);
    // yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);
    // isTalking = false;
    // control.enabled = true;
  // }
}