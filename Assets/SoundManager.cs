using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
}
    /*
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] AudioSource highBgmAudioSource;
    [SerializeField] AudioSource gameOverAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    bool highTension = false;
    bool gameOver = false;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    bool isCalledOnce = false;

    [SerializeField]
    private bool _highTension = false;
    public int HighTensionBGM
    {
        get{ return _highTension; }
        private set
        {
            _boatHealth = value;

            if(_boatHealth <= 0) 
            { 
                Destroy(this);
            }
        }
    }

    Player playerScript;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        script = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }


    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }
    
    public void PlayHightensionBgm()
    {
        
        bgmAudioSource.Stop();
        highBgmAudioSource.Play();
    }

    public void PlayGameOverBgm()
    {
        if(highTension)
        {
            highBgmAudioSource.Stop();
        }
        else
        {
            bgmAudioSource.Stop();
        }
        gameOverAudioSource.Play();
    }/*
}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        Game,
        highTension,
        Clear,
        Over, // これがラベルになる
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        Koban,
        BuffItem,
        debuffItem, 
        Kunai,
        Button,// これがラベルになる
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}*/