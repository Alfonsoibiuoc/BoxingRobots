using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    
    private Slider slider;
    float vida;
    public GameObject fondo;
    Image fill;
    


    // Start is called before the first frame update
    void Start()
    {

        slider = GetComponent<Slider>();
        fill = fondo.GetComponent<Image>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
        vida = GameObject.Find("Personaje").GetComponent<MovimientoPersonaje>().nivelVida;
        
        if ((int)slider.value < 20)
        {

            fill.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 1f));
        }
        else {

            fill.color = Color.Lerp(Color.red, Color.green, vida / slider.maxValue);
        }
    }

}

    

    

