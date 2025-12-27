using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiRightLeft : MonoBehaviour
{
    [SerializeField]
    float xKunaiSpeed = 0f;
    [SerializeField]
    float yKunaiSpeed = 0f;
    [SerializeField]
    bool isMove = false;

    ActivateGimmic activateScript;
    // Start is called before the first frame update
    void Start()
    {
        if(isMove)
        {
            GameObject checkCollision = this.gameObject.transform.GetChild(0).gameObject;
            activateScript = checkCollision.GetComponent<ActivateGimmic>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(activateScript != null)
        {
            if(activateScript.isActivate)
            {
                transform.Translate(xKunaiSpeed * Time.deltaTime, yKunaiSpeed * Time.deltaTime,0);
            }
        }
        else if(!isMove)
        {
            transform.Translate(xKunaiSpeed * Time.deltaTime, yKunaiSpeed * Time.deltaTime,0);
        }
    }
}
