using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
[RequireComponent(typeof(Flowchart))]
public class NpcController : MonoBehaviour
{
    [SerializeField]
    string message = "";
    bool isTalking = false;
    GameObject playerObj;
    NekomataController controller;
    Flowchart flowChart;
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        controller = playerObj.GetComponent<NekomataController>();
        flowChart = GetComponent<Flowchart>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Talk());
        }
    }
    IEnumerator Talk()
    {
        if (isTalking)
        {
            yield break;
        }
        isTalking = true;
        controller.enabled = false;
        controller.Stop();
        flowChart.SendFungusMessage(message);
        yield return new WaitUntil(() => flowChart.GetExecutingBlocks().Count == 0);
        isTalking = false;
        controller.enabled = true;
    }
}