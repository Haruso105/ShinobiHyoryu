using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject CreditPanel;
    [SerializeField] GameObject PlayPanel;

    // Start is called before the first frame update
    void Start()
    {
        BackToMenu();
    }
    public void SelectCreditDescription()
    {
        StartPanel.SetActive(false);
        CreditPanel.SetActive(true);
    }
    public void SelectPlayDescription()
    {
        StartPanel.SetActive(false);
        PlayPanel.SetActive(true);
    }
    public void BackToMenu()
    {
        StartPanel.SetActive(true);
        CreditPanel.SetActive(false);
        PlayPanel.SetActive(false);
    }
}
