using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPresenter : MonoBehaviour {
    
    [SerializeField] Text bgmVolumeText;
    [SerializeField] Slider bgmSlider;

    [SerializeField] Text seVolumeText;
    [SerializeField] Slider seSlider;

    void Start() {
        AudioManager.GetInstance().PlayBGM(0);
    }

    public void OnChangedBGMSlider() {
        AudioManager.GetInstance().BGMVolume = bgmSlider.value;
        bgmVolumeText.text = string.Format("{0:0}", bgmSlider.value*100);
    }

    public void OnChangedSESlider() {
        AudioManager.GetInstance().SEVolume = seSlider.value;
        seVolumeText.text = string.Format("{0:0}", seSlider.value*100);
    }

    public void OnPush() {
        AudioManager.GetInstance().PlaySound(0); // テスト
    }
}