using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour {

    private int i;

    void Start() {
        i = Random.Range(10,13);
        AudioManager.GetInstance().PlayBGM(i);
    }
}
