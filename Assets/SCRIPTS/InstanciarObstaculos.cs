using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarObstaculos : MonoBehaviour
{

    public GameObject[] obstaculos;
    public GameObject plataforma;
    int numobjeto;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Instanciar", Random.Range(4f, 12f), Random.Range(4f, 12f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Instanciar()
    {
        if (GameObject.Find("CONTROLADOR").GetComponent<Control>().iniciar)
        {
            numobjeto = Random.Range(0, obstaculos.Length);
            Instantiate(obstaculos[numobjeto], transform.position, Quaternion.identity);

        }

    }

    public void InstanciarPlataforma() {

        Instantiate(plataforma, transform.position, Quaternion.identity);
    }
}
