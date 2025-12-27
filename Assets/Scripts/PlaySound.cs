using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource highBgmAudioSource;
    [SerializeField] AudioSource gameOverAudioSource;

    bool _highTension = false;
    private bool _gameOver = false;

    public void HighTensionBGM(bool high)
    {
        
        if(_highTension != high)
        {
            _highTension = high;
            if(_highTension == true) 
            { 
                bgmAudioSource.Stop();
                highBgmAudioSource.Play();
            }
            else
            {
                highBgmAudioSource.Stop();
                bgmAudioSource.Play();
            }
        }
    }
        
    public void GameOverBGM(bool gameOverBGM)
    {
        
        if(_gameOver != gameOverBGM)
        {
            _gameOver = gameOverBGM;
            if(_gameOver == true) 
            { 
                bgmAudioSource.Stop();
                highBgmAudioSource.Stop();
                gameOverAudioSource.Play();
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
