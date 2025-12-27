using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessScene : MonoBehaviour
{
    void Start()
    {
        var scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        scoreScript.ReGetComponent();
    }
    public string sceneName; //読み込むシーン名
    
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
