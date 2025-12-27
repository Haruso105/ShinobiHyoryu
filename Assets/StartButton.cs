using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton:MonoBehaviour
{
public void OnClick()
{
SceneManager.LoadScene("OpeningScene");
}
}