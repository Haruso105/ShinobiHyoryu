using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private CharacterController charaCon;      
    private Animator animCon; 
    private Player script;
    public bool isrighting;
    public bool islefting;
    public bool isfronting;
    public bool isbehinding;
    public bool isrunning;
    // Start is called before the first frame update
    void Start()
    {
        charaCon = GetComponent<CharacterController>(); 
        animCon = GetComponent<Animator>(); 
        script=GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        isrighting=script.isrighting;
        islefting=script.islefting;
        isfronting=script.isfronting;
        isbehinding=script.isbehinding;
        isrunning=script.isrunning;
        animCon.SetBool("isrighting", isrighting);
        animCon.SetBool("islefting", islefting);
        animCon.SetBool("isfronting", isfronting);
        animCon.SetBool("isbehinding", isbehinding);
        animCon.SetBool("isrunning", isrunning);
    }
}
