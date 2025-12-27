using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDurability : MonoBehaviour
{
    [SerializeField]
    private int _boatHealth = 2;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoatHealth(int damage)
    {
        _boatHealth -= damage;
        if(_boatHealth <= 0)
        {
            ScoreCounter boat = GameObject.Find("Boat").GetComponent<ScoreCounter>();
            boat.CountIkada();
            Destroy(this.gameObject);
        }
    }
}
