using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItem : MonoBehaviour
{
    [SerializeField] float minN = 0f;
    [SerializeField] float maxN = 0f;

    float locate = 0;
    float randomTime = 0;
    float randomItem = 0;
    float distanceNum = 1f;
    [SerializeField] CountDistance distance;
    [SerializeField] GameObject odango;
    [SerializeField] GameObject koban;
    [SerializeField] GameObject dokubishi;
    [SerializeField] GameObject okusuri;

    [SerializeField] bool onlyKoban = false;
    float kobanCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        RandomNumber();
    }

    // Update is called once per frame
    void Update()
    {
        distanceNum = distance.nowDistance/100;
        if(distanceNum > 10) distanceNum = 10;
        randomTime -= Time.deltaTime;
        kobanCounter += Time.deltaTime;

        if(randomTime <= 0)
        {
            locate = Random.Range(minN, maxN); 
            RandomNumber();
            if(randomItem < 1)
            {
                GameObject launched = Instantiate(koban, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.identity);
            }
            else if(randomItem < 4)
            {
                GameObject launched = Instantiate(odango, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.identity);
            }
            else if(randomItem < 7)
            {
                GameObject launched = Instantiate(dokubishi, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.identity);
            }
            else
            {
                GameObject launched = Instantiate(okusuri, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.identity);
            }
        }
        if(onlyKoban && kobanCounter >= 100)
        {
            GameObject launched = Instantiate(koban, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.identity);
            kobanCounter = 0;
        }
    }

    private void RandomNumber()
    {
        randomItem = Random.Range(0, 10);
        randomTime = Random.Range(5 / (1 + (distanceNum)), 15 / (1 + (distanceNum)));
        
    }
}
