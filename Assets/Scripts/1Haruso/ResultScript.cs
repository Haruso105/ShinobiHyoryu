using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    public int finalIkadaNum = 0;
    public int finalBuffNum = 0;
    public int finalDebuffNum = 0;
    public Text finalIkadaScore;
    public Text finalBuffScore;
    public Text finalDebuffScore;
    public Button returnTitle;

    public float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        finalBuffScore.gameObject.SetActive(false);
        finalDebuffScore.gameObject.SetActive(false);
        finalIkadaScore.gameObject.SetActive(false);
        returnTitle.gameObject.SetActive(false);
        StartCoroutine(displayUIwithdelay());

        var ScoreMan = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        if(ScoreMan != null)
        {
            finalIkadaNum = ScoreMan.finalIkada2;
            finalBuffNum = ScoreMan.finalBuff2;
            finalDebuffNum = ScoreMan.finalDebuff2;
        }
    }

    IEnumerator displayUIwithdelay()
    {

        yield return new WaitForSecondsRealtime(delay);
        finalIkadaScore.gameObject.SetActive(true);
        finalIkadaScore.text = "残りイカダ数 : " + finalIkadaNum;
        yield return new WaitForSecondsRealtime(delay);
        finalBuffScore.gameObject.SetActive(true);
        finalBuffScore.text = "強化アイテム数 : " + finalBuffNum;
        yield return new WaitForSecondsRealtime(delay);
        finalDebuffScore.gameObject.SetActive(true);
        finalDebuffScore.text = "弱化アイテム数 : " + finalDebuffNum;
        yield return new WaitForSecondsRealtime(delay);
        returnTitle.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(delay / 3);
    }

    void Update()
    {
        displayUIwithdelay();
    }

}
