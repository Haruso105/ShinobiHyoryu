
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class resultiniciator : MonoBehaviour
{

    public float gamescore = 0;
    public GameObject GameOverPanel;
    public Image gameOverLogo;
    public Canvas resultcanvas;
    public Text score;
    public Button continu;
    public Button exit;
    public float delay = 2.0f;
    bool isCalledOnce = false;
    [SerializeField] bool isEndless = false;
    CountDistance countD;

    void Start()
    {
        resultcanvas.gameObject.SetActive(false);
        continu.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(false);
        gameOverLogo.gameObject.SetActive(false);
        
        countD = GameObject.Find("ScoreUI").GetComponent<CountDistance>();
    }

    public void ActiveDisplayGameUI()
    {
        if (!isCalledOnce) 
        {
            isCalledOnce = true;
            StartCoroutine(displayUIwithdelay());
            resultcanvas.gameObject.SetActive(true);
            gameOverLogo.gameObject.SetActive(true);
        }
    }

    IEnumerator displayUIwithdelay()
    {
        yield return new WaitForSecondsRealtime(delay);
        gameOverLogo.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(true);
        score.text = "距離 : " + gamescore.ToString("f2") + " km";
        yield return new WaitForSecondsRealtime(delay);
        continu.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay / 3);
    }

    void Update()
    {
        displayUIwithdelay();
        if(!isEndless) gamescore += Time.deltaTime;
        else gamescore = countD.nowDistance;
    }

}



