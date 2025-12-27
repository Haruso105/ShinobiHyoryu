using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider1 : MonoBehaviour
{
    Slider slider;
    public Image sliderImage;

    // Start is called before the first frame update
    void Start()
    {
        slider=this.gameObject.GetComponent<Slider>();
        slider.value=0;
    }

    // Update is called once per frame
    void Update()
    {
      slider.value +=Time.deltaTime; 
    }
}
