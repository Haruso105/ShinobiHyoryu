using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDistance : MonoBehaviour
{
    public float nowDistance = 0;

    [SerializeField] Text score_text;
    [SerializeField] bool showText = false;

    // Start is called before the first frame update
    void Awake()
    {
        score_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        if(playerScript.highTension) nowDistance += Time.deltaTime * 4;
        else nowDistance += Time.deltaTime;
        
        if(showText)
        {
            score_text.text = "距離 : " + nowDistance.ToString("f2") + " km";
        }
    }
}
