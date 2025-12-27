using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletObj;  
    public Transform firePoint;      // 弾を発射する位置（キャラクターの前方など）
    public float bulletSpeed = 10f;  // 弾の速度
    public float rotationSpeed = 10000f;
    public bool isgameover = false;
    public bool isrighting = false;
    public bool islefting = false;
    public bool isfronting = false;
    public bool isbehinding = false;
    public bool isrunning = false;
    public int counter=0;
    public float z;
    ScoreCounter itemCounter;
    [SerializeField]
    GameObject hightentionUI;
    
    public bool isDokubishi = false;
    public bool isOkusuri = false;
    public bool isOdango = false;
    float dokubishiTimer = 0;
    float odangoTimer = 0;
    float okusuriTimer = 0;
    float dokubishiSpeed = 1;
    float okusuriNum = 1;

    public bool highTension = false;
    float htTimer = 0;
    float htSpeed = 1;

    public GameObject floorDetector;   //足場がなくなったか確認
    ObjectDetection objectDetection;

    PlaySound playSound;
    [SerializeField] AudioSource kunaiSE;
    [SerializeField] AudioSource coinSE;
    [SerializeField] AudioSource buffSE;
    [SerializeField] AudioSource debuffSE;


    // Start is called before the first frame update
    void Start()
    {
        objectDetection = floorDetector.GetComponent<ObjectDetection>();
        itemCounter = GameObject.Find("Boat").GetComponent<ScoreCounter>();
        hightentionUI.SetActive(false);
        playSound = GameObject.Find("SoundManager").GetComponent<PlaySound>();
    }

    // Update is called once per frame
    void Update()
    {
        var Vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        
        if(isDokubishi)
        {
            dokubishiTimer += Time.deltaTime;
            dokubishiSpeed = 10f;
            if(dokubishiTimer >= 5f)
            {
                dokubishiSpeed = 1;
                dokubishiTimer = 0f;
                isDokubishi = false;
            }
        }
        if(isOkusuri)
        {
            okusuriTimer += Time.deltaTime;
            okusuriNum = -1;
            if(okusuriTimer >= 5f)
            {
                okusuriTimer = 0f;
                isOkusuri = false;
                okusuriNum = 1;
            }
        }
        if(isOdango)
        {
            odangoTimer += Time.deltaTime;
            if(highTension)
            {
                if(odangoTimer >= 15f)
                {
                    odangoTimer = 0;
                    isOdango = false;
                }
            }
            else
            {
                if(odangoTimer >= 10f)
                {
                    odangoTimer = 0;
                    isOdango = false;
                }
            }
        }

        transform.position += new Vector3((Input.GetAxis("Horizontal") *4f* Time.deltaTime * htSpeed) / dokubishiSpeed * okusuriNum, (Input.GetAxis("Vertical")*4f* Time.deltaTime * htSpeed) / dokubishiSpeed * okusuriNum, 0f);
        
        // 回転の計算
        float rotationAmount = Vertical * rotationSpeed * Time.deltaTime;
        z=transform.localEulerAngles.z;

        // Z軸を中心に回転させる（2Dの場合）
        if (horizontal != 0 || Vertical != 0)
        {
            isrunning = true;
            Vector2 direction = new Vector2(horizontal, Vertical).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (horizontal == 0 && Vertical == 0)
        {
            isrunning = false;
        }
        if((0<=z&&z<=45)||(275<=z&&z<=360))
        {
            isrighting=true;
            islefting = false;
            isfronting = false;
            isbehinding = false;
        }
        if(z>=135&&225>=z)
        {
            isrighting=false;
            islefting = true;
            isfronting = false;
            isbehinding = false;
        }
        if(z>45&&135>z)
        {
            isrighting=false;
            islefting = false;
            isfronting = false;
            isbehinding = true;
        }
        if(z>225&&315>z)
        {
            isrighting=false;
            islefting = false;
            isfronting = true;
            isbehinding = false;
        }

        //transform.Rotate(Vector3.forward, rotationAmount);

        if (((Input.GetKeyDown(KeyCode.Z))||(Input.GetButtonDown("Action"))))
        {
            Shoot();
            kunaiSE.PlayOneShot(kunaiSE.clip);
        }

        if(objectDetection.IsGameOver)
        {
            isgameover = true;
        }

        if(highTension)
        {
            htTimer += Time.deltaTime;

            if(htTimer >= 15)
            {
                highTension = false;
                htSpeed = 1;
                htTimer = 0;
                counter -= 3;
                playSound.HighTensionBGM(false);
            }
        }
    }
    void Shoot()
    {
        Vector2 shootDirection = firePoint.right;

            // 弾を生成
            GameObject bullet = Instantiate(BulletObj, transform.position, Quaternion.identity);

            // 弾のスクリプトを取得して初期化
            shoot bulletScript = bullet.GetComponent<shoot>();
            if (bulletScript)
            {
                bulletScript.Initialize(shootDirection);
                bulletScript.speed = bulletSpeed;
            }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Weapon") && !highTension)
        {
            isgameover=true;
        }
        if (collision.CompareTag("Koban"))
        {
            Destroy(collision.gameObject);
            counter++;
            itemCounter.buffCounts += 1;
            coinSE.PlayOneShot(coinSE.clip);
            if(counter >= 3)
            {
                htSpeed = 2;
                playSound.HighTensionBGM(true);
                if(!highTension)
                {
                    hightentionUI.SetActive(true);
                    isOdango = true;
                    StartCoroutine(displayHightensionUI());
                }
                else if(counter >= 6)
                {
                    counter -= 3;
                    htTimer -= 15;
                }
                highTension = true;
            }
        }
        if (collision.CompareTag("Makibishi"))
        {
            Destroy(collision.gameObject);
            isDokubishi = true;
            dokubishiTimer = 0f;
            itemCounter.debuffCounts += 1;
            debuffSE.PlayOneShot(debuffSE.clip);
        }
        if (collision.CompareTag("Okusuri"))
        {
            Destroy(collision.gameObject);
            isOkusuri = true;
            okusuriTimer = 0f;
            itemCounter.debuffCounts += 1;
            debuffSE.PlayOneShot(debuffSE.clip);
        }
        if (collision.CompareTag("Dango"))
        {
            Destroy(collision.gameObject);
            itemCounter.buffCounts += 1;
            odangoTimer = 0f;
            isOdango = true;
            buffSE.PlayOneShot(buffSE.clip);
        }
    }

    IEnumerator displayHightensionUI()
    {
        yield return new WaitForSecondsRealtime(2f);
        hightentionUI.SetActive(false);
    }
}
