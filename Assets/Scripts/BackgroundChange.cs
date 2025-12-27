using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    Player Coban;
    SpriteRenderer sr;
    float floatspeed = -3f;//���F�̊C������鑬��

    // Start is called before the first frame update
    void Start()
    {
        Coban = GameObject.Find("Player").GetComponent<Player>();//Player�X�N���v�g����counter���擾
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Coban.counter >= 3)
        {
            sr.enabled = true;
            transform.Translate(floatspeed*Time.deltaTime, 0, 0);//�C�����ɓ�����
        }
        else
        {
            sr.enabled = false;
        }
      
       
    }
}
