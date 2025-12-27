using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes4 : MonoBehaviour
{
   void Update()
    {
        if(Input.anyKey) 
        {
        SceneManager.LoadScene("OpeningScene22bai");
        }
    }
}