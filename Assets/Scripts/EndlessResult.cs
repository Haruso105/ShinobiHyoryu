using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessResult : MonoBehaviour
{
    public int finalBuffNum = 0;
    public int finalDebuffNum = 0;
    public float finalDistanceNum = 0;
    public Text finalDistanceScore;
    public Text finalBuffScore;
    public Text finalDebuffScore;
    public Button returnTitle;
    [SerializeField] bool ifRetry = false;
    Button retryButton;

    public float delay = 1f;
    
    void Awake()
    {
        if(ifRetry) retryButton = GameObject.Find("RetryButton").GetComponent<Button>();
        var scoreM = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if(scoreM != null)
        {
            finalDistanceNum = scoreM.finalDistanceScore;
            finalBuffNum = scoreM.finalBuff2;
            finalDebuffNum = scoreM.finalDebuff2;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        finalDistanceScore.gameObject.SetActive(false);
        finalBuffScore.gameObject.SetActive(false);
        finalDebuffScore.gameObject.SetActive(false);
        returnTitle.gameObject.SetActive(false);
        if(retryButton != null) retryButton.gameObject.SetActive(false);
        StartCoroutine(displayUIwithdelay());
    }

    IEnumerator displayUIwithdelay()
    {

        yield return new WaitForSecondsRealtime(delay);
        finalDistanceScore.gameObject.SetActive(true);
        finalDistanceScore.text = "到達距離 : " + finalDistanceNum.ToString("f2") + " km";
        yield return new WaitForSecondsRealtime(delay);
        finalBuffScore.gameObject.SetActive(true);
        finalBuffScore.text = "強化アイテム数 : " + finalBuffNum;
        yield return new WaitForSecondsRealtime(delay);
        finalDebuffScore.gameObject.SetActive(true);
        finalDebuffScore.text = "弱化アイテム数 : " + finalDebuffNum;
        yield return new WaitForSecondsRealtime(delay);
        returnTitle.gameObject.SetActive(true);
        if(retryButton != null) retryButton.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay / 3);
    }


    // Update is called once per frame
    void Update()
    {
        displayUIwithdelay();
    }
}
