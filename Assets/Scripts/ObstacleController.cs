using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float xMoveSpeed = 1.0f;
    public float yMoveSpeed = 0f;
    public int boatDamage = 1;
    
    [SerializeField]
    bool isMove = true;
    [SerializeField]
    bool isCannon = false;

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
        if(activateScript != null )
        {
            if(activateScript.isActivate)
            {
                transform.position += new Vector3(xMoveSpeed * Time.deltaTime, yMoveSpeed * Time.deltaTime, 0f);
            }
        }
        else if(isCannon)
        {
            transform.position += new Vector3(xMoveSpeed * Time.deltaTime, yMoveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            transform.position += new Vector3(xMoveSpeed * Time.deltaTime, yMoveSpeed * Time.deltaTime, 0f);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        BoatDurability boatDurability = collision.GetComponent<BoatDurability>();

        if(boatDurability != null)
        {
            boatDurability.BoatHealth(boatDamage);
            //効果音流すならここ
            Destroy(this.gameObject);
        }
    }
}
