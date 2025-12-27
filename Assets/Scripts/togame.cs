using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sample : MonoBehaviour
{

    [SerializeField] string nextScene = "GameScene";
    private void Start()
    {
        Time.timeScale = 1f;
        //DelayMethodを3.5秒後に呼び出す
        Invoke(nameof(DelayMethod), 6f);
    }

    void DelayMethod()
    {
        SceneManager.LoadScene(nextScene);
    }

}