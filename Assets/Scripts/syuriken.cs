using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float speed = 20.0f;  
    int frameCount = 0;             
    const int deleteFrame = 30;    
    private Player script;
    public int Counter2=0;
    public Rigidbody2D rb;
    private Vector2 direction;

    float odangoKyouka = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        script=GameObject.Find("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Vector2 dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void Update()
    {
        if(script.isOdango)
        {
            odangoKyouka = 40;
        }
        else
        {
            odangoKyouka = 0;
        }

        transform.Translate(direction * speed * Time.deltaTime);
        if (++frameCount > deleteFrame + odangoKyouka)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Ryuboku"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
