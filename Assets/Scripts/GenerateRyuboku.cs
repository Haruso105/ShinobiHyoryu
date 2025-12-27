using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRyuboku : MonoBehaviour
{
    [SerializeField] float minN = 0f;
    [SerializeField] float maxN = 0f;

    [SerializeField] bool isXAxis = true;
    float locate = 0;
    float randomTime = 0;
    [SerializeField] CountDistance distance;
    [SerializeField] GameObject generateObject;
    [SerializeField] GameObject generateObject2;
    int randomRyuboku = 1;

    float distanceNum = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        randomTime = Random.Range(1, 15);
        randomRyuboku = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(distance.nowDistance/111 < 10) distanceNum = distance.nowDistance/111;
        else
        {
            distanceNum = 10;
        }

        randomTime -= Time.deltaTime;

        if(randomTime <= 0)
        {
            locate = Random.Range(minN, maxN); 
            RandomNumber();
            if(isXAxis) 
            {
                if(randomRyuboku == 1)
                {
                    GameObject launched = Instantiate(generateObject, new Vector3 (this.transform.position.x + locate, this.transform.position.y, 0.0f), Quaternion.identity);
                }
                else
                {
                    GameObject launched = Instantiate(generateObject2, new Vector3 (this.transform.position.x + locate, this.transform.position.y, 0.0f), Quaternion.identity);
                }
            }
            else
            {
                if(randomRyuboku == 1)
                {
                    GameObject launched = Instantiate(generateObject, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.identity);
                }
                else
                {
                    GameObject launched = Instantiate(generateObject2, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.identity);
                }
            }
        }
    }

    private void RandomNumber()
    {
        randomTime = Random.Range(10 / 1 + (distanceNum), 25 / 1 + (distanceNum));
        randomRyuboku = Random.Range(1, 3);
    }
}
