using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGimmic : MonoBehaviour
{

    [SerializeField]
    private bool isCannon = false;
    [SerializeField]
    private bool isLaunch = false;
    [SerializeField]
    GameObject weaponPrefab;
    /*
    [SerializeField]
    private bool isBarrel = false;
    */

    public bool isActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        if(isLaunch)
        {
            var sr = GetComponent<SpriteRenderer>();
            sr.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if(other.CompareTag("Respawn"))
        {
            if(isCannon)
            {
                GameObject cannonBall = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(0f, 0f, 70.0f));
            }
            else if(isBarrel)
            {
                GameObject cannonBall = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(0f, 0f, 90.0f));
            }
            else
            {
                GameObject kunai = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
        */
        if(other.CompareTag("Respawn"))
        {
            if(isLaunch)
            {
                if(isCannon)
                {
                    GameObject cannonBall = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(0f, 0f, 70.0f));
                }
                else
                {
                    GameObject weapon = Instantiate(weaponPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
                }
            }
            isActivate = true;
        }

    }
}