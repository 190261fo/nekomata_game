using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

[RequireComponent(typeof(Flowchart))]
public class NPCController : MonoBehaviour
{
    [SerializeField]
    string message = "";
    GameObject playerObj;
    Flowchart flowChart;
    playermove player;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<playermove>();
        flowChart = GetComponent<Flowchart>();
    }
    private  void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Talk());
        }
    }
   
    IEnumerator Talk()
    {
        player.SetState(playermove.State.Talk);

        flowChart.SendFungusMessage(message);
        yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);

        player.SetState(playermove.State.Normal);
    }
}