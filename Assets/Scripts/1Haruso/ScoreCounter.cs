using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    GameObject[] ikadaObjects;
    public int ikadaCounts = 32;
    public int buffCounts = 0;
    public int debuffCounts = 0;
    [SerializeField] 
    AudioSource damageSE;

    void Start()
    {
        ikadaCounts = 32;
    }

    public void CountIkada()
    {
        /*ikadaObjects = GameObject.FindGameObjectsWithTag("Ikada");
        ikadaCounts = ikadaObjects.Length;*/
        damageSE.PlayOneShot(damageSE.clip);
        ikadaCounts -= 1;
    }
}
