using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoqueCabeza : MonoBehaviour
{

    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstaculos")
        {
            personaje.GetComponent<MovimientoPersonaje>().choqueObstaculo();

        }
    }
    }
