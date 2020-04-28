using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlNiveles : MonoBehaviour
{
    public bool bloqueoNivel2 = false;
    public bool bloqueoNivel3 = false;
    public GameObject bloqueo2;
    public GameObject bloqueo3;

    public GameObject panel;
    private Animator animPanel;
    public int escena;
    public AudioSource seleccionar;


    // Start is called before the first frame update
    void Start()
    {
        
        animPanel = panel.GetComponent<Animator>();

        if (GameObject.Find("OPCIONES").GetComponent<Opciones>().nivel1Completado)
        {

            bloqueoNivel2 = false;
            bloqueo2.SetActive(false);

        }
        else {

            bloqueoNivel2 = true;
        }

        if (GameObject.Find("OPCIONES").GetComponent<Opciones>().nivel2Completado)
        {

            bloqueoNivel3 = false;
            bloqueo3.SetActive(false);

        }
        else
        {

            bloqueoNivel3 = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("OPCIONES").GetComponent<Opciones>().desbloqueado2) {

            animPanel.SetTrigger("desbloqueo2");
            GameObject.Find("OPCIONES").GetComponent<Opciones>().desbloqueado2 = false;
        }
        if (GameObject.Find("OPCIONES").GetComponent<Opciones>().desbloqueado3)
        {

            animPanel.SetTrigger("desbloqueo3");
            GameObject.Find("OPCIONES").GetComponent<Opciones>().desbloqueado3 = false;
        }
    }

    

    public void botonNivel1() {

        seleccionar.Play();
        escena = 1;
        GameObject.Find("OPCIONES").GetComponent<Opciones>().nivelActual = 1;
        animPanel.SetTrigger("Level1");
        
    }
    public void botonNivel2()
    {

        if (!bloqueoNivel2)
        {
            seleccionar.Play();
            escena = 2;
            GameObject.Find("OPCIONES").GetComponent<Opciones>().nivelActual = 2;
            animPanel.SetTrigger("Level2");
        }
    }
    public void botonNivel3()
    {

        if (!bloqueoNivel3)
        {
            seleccionar.Play();
            escena = 3;
            GameObject.Find("OPCIONES").GetComponent<Opciones>().nivelActual = 3; 
            animPanel.SetTrigger("Level3");
        }
    }
    public void botonVolver()
    {

        SceneManager.LoadScene("1_MenuPrincipal");
    }

}
