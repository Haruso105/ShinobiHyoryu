using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{

    private Collider2D playerCollider;
    public List<Collider2D> backgroundDetected = new List<Collider2D>();
    public GameObject playerTransform;
    Transform objectTransform;
    public bool IsGameOver = false;
    float countTime;

    void Start()
    {
        
        objectTransform = gameObject.GetComponent<Transform>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 背景に触れたときにリストに追加
        if (other.CompareTag("Ikada"))
        {
            backgroundDetected.Add(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 背景から離れたときにリストから削除
        if (backgroundDetected.Contains(other))
        {
            backgroundDetected.Remove(other);
        }
    }

    void Update()
    {
        countTime += Time.deltaTime;
        objectTransform.position = new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y -0.5f, 0);

        if(backgroundDetected?.Count <= 0 && countTime >= 1)
        {
            IsGameOver = true;
        }
    }
}
