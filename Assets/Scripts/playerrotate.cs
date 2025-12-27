using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LockRotation : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float fixedAngle = 0f;
    

    void Start()
    {
        // 回転をロック
        rb2d.freezeRotation = true;
    }
    void FixedUpdate()
    {
        // 現在の回転を固定する
        transform.rotation = Quaternion.Euler(0, 0, fixedAngle);
    }
}