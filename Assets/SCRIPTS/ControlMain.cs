using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMain : MonoBehaviour
{
    public GameObject panelOpciones;
    public GameObject panelGeneral;
    Animator animPanelOpciones;
    Animator animPanelGeneral;
    public GameObject botonON;
    public GameObject botonOFF;
    public Slider slider;
    public float dificultad;
    public bool sonido;
    public AudioSource menuOpciones;
    public AudioSource seleccionar;
    public GameObject opciones;

    // Start is called before the first frame update
    void Start()
    {

        opciones = GameObject.Find("OPCIONES");

        if (opciones.GetComponent<Opciones>().sonido)
        {

            botonOFF.SetActive(true);
            botonON.SetActive(false);
        }
        else {

            botonOFF.SetActive(false);
            botonON.SetActive(true);
        }

        slider.value = opciones.GetComponent<Opciones>().dificultad;





        //sonido = true;
        animPanelOpciones = panelOpciones.GetComponent<Animator>();
        animPanelGeneral = panelGeneral.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sonido);
        
    }

    public void pulsaOpciones() {
        menuOpciones.Play();
        animPanelOpciones.SetTrigger("Entrar");
    
    }

    public void pulsarSalir() {
        menuOpciones.Play();
        animPanelOpciones.SetTrigger("Salir");
    }

    public void pulsarPlay() {
        seleccionar.Play();
        animPanelGeneral.SetTrigger("Play");
        
    }

    public void SonidoON() {
        sonido = true;
        botonON.SetActive(false);
        botonOFF.SetActive(true);
        GameObject.Find("OPCIONES").GetComponent<Opciones>().sonido = sonido;
        
    }


    public void sonidoOFF() {
        sonido = false;
        botonOFF.SetActive(false);
        botonON.SetActive(true);
        GameObject.Find("OPCIONES").GetComponent<Opciones>().sonido = sonido;

    }

    public void cambioDificultad() {

        dificultad = slider.value;
        GameObject.Find("OPCIONES").GetComponent<Opciones>().dificultad = dificultad;
    }
    public void Salir()
    {
        Application.Quit();

    }

}
