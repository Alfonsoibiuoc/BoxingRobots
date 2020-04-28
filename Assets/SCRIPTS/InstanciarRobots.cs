using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarRobots : MonoBehaviour
{
    public GameObject Robot;
    
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Instanciar", Random.Range(10f, 20f), Random.Range(10f, 20f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Instanciar()
    {
        if (GameObject.Find("CONTROLADOR").GetComponent<Control>().iniciar)
        {
            
            Instantiate(Robot, transform.position, Quaternion.identity);

        }

    }

    
}
