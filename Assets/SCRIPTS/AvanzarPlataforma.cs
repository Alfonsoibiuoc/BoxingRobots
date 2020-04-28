using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvanzarPlataforma : MonoBehaviour
{
    
    private Control c;
    
    public float ajuste;
    

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
            
                transform.Translate(Vector3.forward * Time.deltaTime * c.offset * ajuste);
           

        }


    }

   






}
