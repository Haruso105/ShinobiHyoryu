using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainscenes2 : MonoBehaviour
{
    public enum GAME_STATUS { Play, Clear, Pause, GameOver,Start };
    public static GAME_STATUS status;
    public GameObject resultManager;
    resultiniciator rmScript;

    [SerializeField]
    GameObject clearUI;
    [SerializeField]
    GameObject gameoverUI;
    [SerializeField]
    GameObject pauseUI;
    [SerializeField]
    GameObject startUI;
    [SerializeField]
    GameObject abekobeUI;
    [SerializeField]
    GameObject slowUI;
    [SerializeField]
    GameObject hikyoriUI;

    public GameObject soundManage;
 
    private Player script;
    private goal script2;
    private CharacterController charaCon;
    private Animator animCon;  
    private bool isbarraging = false; 
    private bool isgameover; 
    private bool isclear; 
    public float time;

    SceneManagement sceneManage;
    public PlaySound playSound;

    // Start is called before the first frame update
    void Start()
    {
        charaCon = GetComponent<CharacterController>(); 
        animCon = GetComponent<Animator>();
        script=GameObject.Find("Player").GetComponent<Player>();
        script2=GameObject.Find("seaend").GetComponent<goal>();
        status = GAME_STATUS.Start;
        clearUI.SetActive(false);
        gameoverUI.SetActive(false);
        pauseUI.SetActive(false);
        startUI.SetActive(true);
        abekobeUI.SetActive(false);
        slowUI.SetActive(false);
        hikyoriUI.SetActive(false);
        Time.timeScale=2f;
        Application.targetFrameRate=60;
        time = 0.0f;
        
        rmScript = GameObject.Find ("resultmanager").GetComponent<resultiniciator>();
        sceneManage = GetComponent<SceneManagement>();
        playSound = GameObject.Find("SoundManager").GetComponent<PlaySound>();
       
    }

    // Update is called once per frame
    void Update()
    {
    int Counter=script.counter;
    isgameover=script.isgameover;
    isclear=script2.isclear;

    if(status == GAME_STATUS.Play)
    {
        time += Time.deltaTime;
    }
    if(status == GAME_STATUS.Start)
    {
        Time.timeScale = 0f;
        script.enabled = false;
        StartCoroutine(DelayCoroutine3());
    }

    if (isclear==true)
    {
        status = GAME_STATUS.Clear;      
    }

    if (isgameover==true)
    {
        status = GAME_STATUS.GameOver;
    } 
    if (((Input.GetKeyDown(KeyCode.X))||(Input.GetButtonDown("Action4")))&&status == GAME_STATUS.Play)
        {
             status = GAME_STATUS.Pause;
             isbarraging=true;
             StartCoroutine(DelayCoroutine());
        }

    if (status == GAME_STATUS.GameOver)
    {
        rmScript.ActiveDisplayGameUI();
        playSound.GameOverBGM(true);
        Time.timeScale = 0f;
        script.enabled = false;
    }
    if (status == GAME_STATUS.Clear)
        {
            clearUI.SetActive(true);
            Time.timeScale = 0f;
            script.enabled = false;
            StartCoroutine(DelayCoroutine2());
        }
    if (status == GAME_STATUS.Pause)
    {
        pauseUI.SetActive(true);
            Time.timeScale = 0f;
            script.enabled = false;
            

        if (((Input.GetKeyDown(KeyCode.X))||(Input.GetButtonDown("Action4")))&&!isbarraging)
        {
            status = GAME_STATUS.Play;
            Time.timeScale = 2f;
            script.enabled = true;
            pauseUI.SetActive(false);
        }  
    }
    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        isbarraging =false;
    }
    IEnumerator DelayCoroutine2()
    {
        yield return new WaitForSecondsRealtime(3f);
        sceneManage.beforeLoad();
    }
    IEnumerator DelayCoroutine3()
    {
        yield return new WaitForSecondsRealtime(2f);
        startUI.SetActive(false);
        status = GAME_STATUS.Play;
        Time.timeScale = 2f;
        script.enabled = true;
        
    }

    if(script.isOdango) hikyoriUI.SetActive(true);
    else    hikyoriUI.SetActive(false);

    if(script.isDokubishi) slowUI.SetActive(true);
    else    slowUI.SetActive(false);

    if(script.isOkusuri) abekobeUI.SetActive(true);
    else    abekobeUI.SetActive(false);
    
    }
}