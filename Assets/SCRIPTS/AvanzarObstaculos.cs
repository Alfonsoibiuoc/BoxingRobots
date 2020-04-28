using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvanzarObstaculos : MonoBehaviour
{
    private Control c;
    
    public float ajuste;
    public bool enSuelo;
    public GameObject explosionRobot;
   

    // Start is called before the first frame update
    void Start()
    {
        
       

            c = GameObject.Find("CONTROLADOR").GetComponent<Control>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (c.iniciar)
        {
            if (enSuelo) {

                transform.Translate(Vector3.forward * Time.deltaTime * c.offset * ajuste);
            }

            
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        enSuelo = true;
    }
   






}
