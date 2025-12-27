using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMoving : MonoBehaviour
{

    float Boatspeed = 1.0f;
    //�C�J�_�̑���

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Boatspeed * Time.deltaTime, 0,0);
    }
}
