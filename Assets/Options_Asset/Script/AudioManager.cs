using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class AudioManager : MonoBehaviour {
    
    [SerializeField] AudioClip[] bgmList;
    [SerializeField] AudioSource audioSourceBGM;

    [SerializeField] AudioClip[] seList;
    [SerializeField] AudioSource audioSourceSE;

    public WriterAudio writerAudio;

    public float BGMVolume {
        get { return audioSourceBGM.volume; }
        set { audioSourceBGM.volume = value; }
    }

    public float SEVolume {
        get { return audioSourceSE.volume; }
        set { audioSourceSE.volume = value; }
    }

    //SecneをまたいでもObjectが破壊されないようにする
    static AudioManager Instance = null;

    public static AudioManager GetInstance() {
        if (Instance == null) {
            Instance = FindObjectOfType<AudioManager>();
        }
        return Instance;
    }

    private void Awake() {
        if(this != GetInstance()) {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    //BGMを再生する関数を作成
    public void PlayBGM(int index) {
        audioSourceBGM.clip = bgmList[index];
        audioSourceBGM.Play();
    }

    //SEを再生する関数を作成
    public void PlaySound(int index) {
        audioSourceSE.PlayOneShot(seList[index]);
    }

}
