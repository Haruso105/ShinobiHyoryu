using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public string sceneName; //読み込むシーン名
    private ScoreCounter scoreCount;

    [SerializeField]
    private bool checkNum = true;

    private int num;
    private int num2;
    private int num3;

    public void Load()
    {
        if(checkNum)
        {
            scoreCount = GameObject.Find("Boat").GetComponent<ScoreCounter>();
        }
        
        // イベントに登録
        if(scoreCount != null)
        {
            num = scoreCount.ikadaCounts;
            num2 = scoreCount.buffCounts;
            num3 = scoreCount.debuffCounts;
            SceneManager.sceneLoaded += GameSceneLoaded;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void beforeLoad()
    {
        Load();
    }

   private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        //シーン切り替え後のスクリプトを取得
        var resultScript = GameObject.Find("Canvas").GetComponent<ResultScript>();

        if(resultScript != null)
        {
            // データを渡す処理
            resultScript.finalIkadaNum = num;
            resultScript.finalBuffNum = num2;
            resultScript.finalDebuffNum = num3;
        }

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}