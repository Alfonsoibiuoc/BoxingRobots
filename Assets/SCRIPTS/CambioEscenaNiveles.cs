using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaNiveles : MonoBehaviour
{
    int escena;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambioEscena()
    {

        escena = GameObject.Find("CONTROLADORNIVELES").GetComponent<ControlNiveles>().escena;
        
        switch (escena)
        {

            case 1:
                SceneManager.LoadScene("3_Nivel1");
                break;

            case 2:
                SceneManager.LoadScene("4_Nivel2");
                break;

            case 3:
                SceneManager.LoadScene("5_Nivel3");
                break;

        }

    }
}
