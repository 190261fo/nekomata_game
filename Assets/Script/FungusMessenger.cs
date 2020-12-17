using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Fungus;

public class FungusMessenger : MonoBehaviour
{
    public Fungus.Flowchart flowchart = null;
    public string message = "";
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (flowchart && collision.gameObject.tag == "Player")
        {
            flowchart.SendFungusMessage(message);
        }
    }

    private void OnCollisionEnter2D(Trigger2D trigger)
    {
        if (flowchart && trigger.gameObject.tag == "Player")
        {
            flowchart.SendFungusMessage(message);
        }
    }
}
