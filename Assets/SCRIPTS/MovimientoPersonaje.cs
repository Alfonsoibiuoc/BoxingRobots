using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Swipe { None, Up, Down, Left, Right };

public class MovimientoPersonaje : MonoBehaviour
{
    Animator anim;
    public bool IniciarCarrera;
    
    public float fuerza = 1000f;
    bool puedeSaltar = true;
    Rigidbody rb;
    public float nivelVida = 100;
    public float valorImpacto = 25;
    public float numCarril;
    public GameObject Camara;
    public GameObject golpe;
    public int acumuladoObstaculos;
    public Transform posicionador;
    public AudioSource Fondo;
    public AudioSource Golpe;
    public AudioSource Eliminado;
    public AudioSource Win;
    public AudioSource rodar;
    public AudioSource saltar;
    public AudioClip ClipGanar;

    public int carril;
    public Vector3 Posicion;
    public GameObject Posicion0;
    public GameObject Posicion1;
    public GameObject Posicion2;
    public AudioSource Mover;

    //ControlAndroid
    public float minSwipeLength = 5f;   
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Vector2 firstClickPos;
    Vector2 secondClickPos;

    public float angulo;

    public static Swipe swipeDirection;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //carril = 2;
        //Posicion = transform.position;
        rb = GetComponent<Rigidbody>();
        acumuladoObstaculos = 0;
    }

    // Update is called once per frame
    void Update()
    {

        DetectSwipe();

        //transform.position = posicionador.position;
        //Vector3 T = posicionador.position;
        //transform.position = new Vector3(T.x, transform.position.y, transform.position.z);

        if (nivelVida <= 0)
        {

            IniciarCarrera = false;
            GameObject.Find("CONTROLADOR").GetComponent<Control>().SinVida = true;

        }
        Vector3 cambioPosicion = Vector3.Lerp(transform.position, Posicion, 10 * Time.deltaTime);
        transform.position = new Vector3(cambioPosicion.x, transform.position.y, transform.position.z);



    }
    public void DetectSwipe() {

    if (IniciarCarrera)
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    swipeDirection = Swipe.None;
                    return;
                }

                currentSwipe.Normalize();

                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -angulo && currentSwipe.x < angulo)
                {
                    swipeDirection = Swipe.Up;
                    if (puedeSaltar)
                    {
                        saltar.Play();
                        anim.SetTrigger("Salto");
                        rb.AddForce(0, fuerza, 0, ForceMode.Impulse);
                        puedeSaltar = false;

                    }
                    // Swipe down
                }
                else if (currentSwipe.y < 0 && currentSwipe.x > -angulo && currentSwipe.x < angulo)
                {
                    swipeDirection = Swipe.Down;
                    rodar.Play();
                    anim.SetBool("Rodar", true);
                       
                        
                }
                else if (currentSwipe.x < 0 && currentSwipe.y > -angulo && currentSwipe.y < angulo)
                    {
                        //swipeDirection = Swipe.Left;
                        switch (carril) {

                            case 0:

                                Debug.Log("Fuera");
                                break;
                            case 1:
                                carril = 0;
                                Posicion = Posicion0.transform.position;
                                break;
                            case 2:
                                carril = 1;
                                Posicion = Posicion1.transform.position;
                                break;
                        
                        }

                        // Swipe right
                    }
                else if (currentSwipe.x > 0 && currentSwipe.y > -angulo && currentSwipe.y < angulo)
                    {
                        //swipeDirection = Swipe.Right;
                        switch (carril)
                        {

                            case 0:
                                carril = 1;
                                Posicion = Posicion1.transform.position;
                                
                                break;
                            case 1:
                                carril = 2;
                                Posicion = Posicion2.transform.position;
                                break;
                            case 2:
                                Debug.Log("Fuera");
                                break;

                        }
                    }

                }
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {
                firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            else
            {
                swipeDirection = Swipe.None;
                //Debug.Log ("None");
            }
            if (Input.GetMouseButtonUp(0))
            {
                secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                currentSwipe = new Vector3(secondClickPos.x - firstClickPos.x, secondClickPos.y - firstClickPos.y);

                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    swipeDirection = Swipe.None;
                    return;
                }

                currentSwipe.Normalize();

                //Swipe directional check
                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -angulo && currentSwipe.x < angulo)
                {
                    swipeDirection = Swipe.Up;
                    if (puedeSaltar)
                    {
                        saltar.Play();
                        anim.SetTrigger("Salto");
                        rb.AddForce(0, fuerza, 0, ForceMode.Impulse);
                        puedeSaltar = false;

                    }
                    // Swipe down
                }
                else if (currentSwipe.y < 0 && currentSwipe.x > -angulo && currentSwipe.x < angulo)
                {
                    swipeDirection = Swipe.Down;
                    rodar.Play();
                    anim.SetBool("Rodar", true);
                    
                }
                    else if (currentSwipe.x < 0 && currentSwipe.y > -angulo && currentSwipe.y < angulo)
                    {
                        //swipeDirection = Swipe.Left;
                        switch (carril)
                        {

                            case 0:

                                Debug.Log("Fuera");
                                break;
                            case 1:
                                carril = 0;
                                Posicion = Posicion0.transform.position;
                                break;
                            case 2:
                                carril = 1;
                                Posicion = Posicion1.transform.position;
                                break;

                        }

                        // Swipe right
                    }
                    else if (currentSwipe.x > 0 && currentSwipe.y > -angulo && currentSwipe.y < angulo)
                    {
                        //swipeDirection = Swipe.Right;
                        switch (carril)
                        {

                            case 0:
                                carril = 1;
                                Posicion = Posicion1.transform.position;

                                break;
                            case 1:
                                carril = 2;
                                Posicion = Posicion2.transform.position;
                                break;
                            case 2:
                                Debug.Log("Fuera");
                                break;

                        }
                    }


                }

        }
            anim.SetTrigger("Correr");

        }

    }
    

    public void correr() {
        anim.SetBool("Rodar", false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo")) {

            puedeSaltar = true;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstaculos")
        {
            choqueObstaculo();

        }
        if(other.tag == "Plataforma")
        {
            choquePlataforma();
            

        }
    }

    public void choqueObstaculo() {
        
        acumuladoObstaculos++;
        nivelVida = nivelVida - valorImpacto;
        if (nivelVida > 0)
        {
            Golpe.Play();
            Instantiate(golpe, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
            anim.SetTrigger("Tropezar");
        }
    }

    public void choquePlataforma() {
        Fondo.Stop();
        
        anim.SetTrigger("Victoria");

        IniciarCarrera = false;
        GameObject.Find("CONTROLADOR").GetComponent<Control>().iniciar = false;
        Camara.GetComponent<Animator>().SetTrigger("Final");
        
        Win.PlayOneShot(ClipGanar, 0.6f);
        StartCoroutine(FinalNivel());

    }

    IEnumerator FinalNivel() {

        int nivel = GameObject.Find("OPCIONES").GetComponent<Opciones>().nivelActual;

        switch (nivel) {

            case 1:
                GameObject.Find("OPCIONES").GetComponent<Opciones>().nivel1Completado = true;
                GameObject.Find("OPCIONES").GetComponent<Opciones>().desbloqueado2 = true;
                GameObject.Find("OPCIONES").GetComponent<Opciones>().Guargar();
                break;
            case 2:
                GameObject.Find("OPCIONES").GetComponent<Opciones>().nivel2Completado = true;
                GameObject.Find("OPCIONES").GetComponent<Opciones>().desbloqueado3 = true;
                GameObject.Find("OPCIONES").GetComponent<Opciones>().Guargar();
                break;
            
                
                
        }
        
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("2_MenuNiveles");


    }
    



}
    
    

