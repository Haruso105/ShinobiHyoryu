using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image1 : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite oldSprite;
    public Image image;
    private Player script;

    // Start is called before the first frame update
    void Start()
    {
    script=GameObject.Find("Player").GetComponent<Player>();
    image=GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    int Counter=script.counter;
    if (Counter>=1)
    {
        image.sprite=newSprite;
    }
        if (Counter<=0)
    {
        image.sprite=oldSprite;
    }
    }
}