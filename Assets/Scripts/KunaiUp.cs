using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiUp : MonoBehaviour
{
    [SerializeField]
    float KunaiUpspeed = 1f;
    [SerializeField]
    float KunaiRightspeed = 1f;

    ActivateGimmic activateScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject checkCollision = this.gameObject.transform.GetChild(0).gameObject;

        activateScript = checkCollision.GetComponent<ActivateGimmic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activateScript.isActivate)
        {
            transform.Translate(KunaiRightspeed * Time.deltaTime,KunaiUpspeed * Time.deltaTime,0);
        }
    }
}
