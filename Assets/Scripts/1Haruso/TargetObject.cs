using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    [SerializeField] float rotate = 0;
    [SerializeField] float xlocate = 0;
    [SerializeField] float ylocate = 0;
    [SerializeField] bool isXaxis = true;
    [SerializeField] CountDistance distance;
    [SerializeField] GameObject generateObject;
    public GameObject playersTransform;
    Transform thisTransform;


    public float randomTime = 0;
    float distanceNum = 1f;

    private void Awake()
    {
        thisTransform = gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(1, 25);
    }

    // Update is called once per frame
    void Update()
    {
        var playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

        if(isXaxis) thisTransform.position = new Vector3(xlocate + playerTransform.transform.position.x, this.transform.position.y, 0);
        else thisTransform.position = new Vector3(this.transform.position.x, ylocate + playerTransform.transform.position.y, 0);

        if(distance.nowDistance/100 < 15) distanceNum = distance.nowDistance/100;
        else distanceNum = 15;

        randomTime -= Time.deltaTime;

        if(randomTime <= 0)
        {
            RandomNumber();
            GameObject launched = Instantiate(generateObject, new Vector3 (this.transform.position.x, this.transform.position.y, 0.0f), Quaternion.Euler(0, 0, 0 + rotate));
        }
    }

    private void RandomNumber()
    {
        randomTime = Random.Range(10 / (1 + (distanceNum)), 25 / (1 + (distanceNum)));
    }
}
