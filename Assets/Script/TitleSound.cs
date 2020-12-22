using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSound : MonoBehaviour {
    
    void Start() {
        AudioManager.GetInstance().PlayBGM(1);
    }
}