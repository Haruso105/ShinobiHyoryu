using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Weapon") || collision.CompareTag("Koban") || collision.CompareTag("Makibishi") || collision.CompareTag("Okusuri") || collision.CompareTag("Dango") || collision.CompareTag("Ryuboku"))
        {
            Destroy(collision.gameObject);
        }
    }
}
