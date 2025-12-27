using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomSpeed : MonoBehaviour
{
    CountDistance distance;
    [SerializeField] float minN = 0.3f;
    [SerializeField] float maxN = 0.5f;
    float xSpeed = 0f;
    float speed = 0f;
    [SerializeField] bool moveX;
    [SerializeField] bool isMinus = false;
    [SerializeField] bool isKunai = false;

    void Start()
    {
        distance = GameObject.Find("ScoreUI").GetComponent<CountDistance>();
        if(maxN + 1 * distance.nowDistance/200 < 4)
        {
            speed = Random.Range(minN, maxN + (1 * (distance.nowDistance/200)));
        }
        else
        {
            speed = Random.Range(1, 4);
        }
        if(isMinus) speed *= -1;

        xSpeed = Random.Range(0, 0.7f);
        float minus = Random.Range(-1 , 1);
        if(minus < 0) xSpeed = xSpeed * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveX) transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed, transform.position.y, 0f);


        else if(isKunai)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime * speed, 0f);
        } 
        
        else transform.position = new Vector3 (transform.position.x + Time.deltaTime * xSpeed, transform.position.y + Time.deltaTime * speed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        BoatDurability boatDurability = collision.GetComponent<BoatDurability>();

        if(boatDurability != null)
        {
            boatDurability.BoatHealth(1);
            //効果音流すならここ
            Destroy(this.gameObject);
        }
    }
}