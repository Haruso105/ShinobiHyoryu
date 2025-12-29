using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] float minN = 0f;
    [SerializeField] float maxN = 0f;

    [SerializeField] bool isXAxis = true;
    [SerializeField] bool isInvert = true;
    [SerializeField] bool isRotate = true;
    float invert = 0;
    float rotate = 90;
    float locate = 0;
    float randomTime = 0;
    [SerializeField] CountDistance distance;
    [SerializeField] GameObject generateObject;

    float distanceNum = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        randomTime = Random.Range(1, 25);
        if(isInvert) invert = 180f;
        if(isRotate) rotate = -90;
    }

    // Update is called once per frame
    void Update()
    {
        if(distance.nowDistance/100 < 10) distanceNum = distance.nowDistance/100;
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
                GameObject launched = Instantiate(generateObject, new Vector3 (this.transform.position.x + locate, this.transform.position.y, 0.0f), Quaternion.Euler(0, 0, 0 + rotate));
            }
            else 
            {
                GameObject launched = Instantiate(generateObject, new Vector3 (this.transform.position.x, this.transform.position.y + locate, 0.0f), Quaternion.Euler(0, 0, 0 + invert));
            }
        }
    }

    private void RandomNumber()
    {
        randomTime = Random.Range(15 / 1 + (distanceNum), 35 / 1 + (distanceNum));
    }
}
