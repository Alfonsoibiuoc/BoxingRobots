using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AvanzarRobots : MonoBehaviour
{
    private Control c;
    public float ajuste;
    public int carril;
    public Vector3 Posicion;
    public float numCarril;
    Animator anim;
    //int golpes;
    public GameObject explosionRobot;
    public AudioSource Golpearse;
    public AudioSource explosion;
   

    // Start is called before the first frame update
    void Start()
    {
        Golpearse = GameObject.Find("Choque").GetComponent<AudioSource>();
        explosion = GameObject.Find("choqueRobots").GetComponent<AudioSource>();

        c = GameObject.Find("CONTROLADOR").GetComponent<Control>();
        anim = GetComponent<Animator>();
        carril = 2;
        Posicion = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (c.iniciar)
        {

            transform.Translate(Vector3.forward * Time.deltaTime * c.offset * ajuste);
           
        }
    }
    public void Chocar() {

        int muerte = Random.Range(1, 4);
        Debug.Log(muerte);
        ajuste = 0;
        switch (muerte)
        {


            case 1:
                anim.SetTrigger("Eliminado1");
                break;
            case 2:
                anim.SetTrigger("Eliminado2");
                break;
            case 3:
                anim.SetTrigger("Eliminado3");
                break;


        }
        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstaculos")
        {
            CapsuleCollider colisionador;
            colisionador = GetComponent<CapsuleCollider>();
            colisionador.enabled = !colisionador.enabled;
            Rigidbody rb;
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            Golpearse.Play();
            Chocar();
            Destroy(other.gameObject);

        }

    }
    public void Eliminado() {
        explosion.Play();
        Instantiate(explosionRobot, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), Quaternion.identity);
        Destroy(gameObject);
    }

}
