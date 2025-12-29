using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    CountDistance countD;
    ScoreCounter scoreCount;
    public float finalDistanceScore; 
    public int finalIkada2; 
    public int finalBuff2; 
    public int finalDebuff2;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("DontDestroyTest");
        if(objects.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad (this);
    }
    void Start()
    {
        countD = GameObject.Find("ScoreUI").GetComponent<CountDistance>();
        scoreCount = GameObject.Find("Boat").GetComponent<ScoreCounter>();
        finalDistanceScore = 0;
        finalIkada2 = 0;
        finalBuff2 = 0; 
        finalDebuff2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(countD != null)
        {
            finalDistanceScore = countD.nowDistance;
        }
        if(scoreCount != null)
        {
            finalIkada2 = scoreCount.ikadaCounts;
            finalBuff2 = scoreCount.buffCounts;
            finalDebuff2 = scoreCount.debuffCounts;
        }
    }
    
    public void ReGetComponent()
    {
        countD = GameObject.Find("ScoreUI").GetComponent<CountDistance>();
        scoreCount = GameObject.Find("Boat").GetComponent<ScoreCounter>();
    }
}
