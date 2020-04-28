using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public GameObject imagen3;
    public GameObject imagen2;
    public GameObject imagen1;
    public GameObject imagen0;
    public bool iniciar;
    public bool SinVida = false;
    public GameObject jugador;
    public GameObject Panel;
    public GameObject recorrido;
    public GameObject planeta;
    public float offset;
    public float ajuste;
    private float StartTime;
    private float StartPlatform;
    public GameObject contador;
    public GameObject contadorPlataforma;
    public float TimerControl;
    public float platformControl;
    public GameObject generadorCentro;
    private bool enRecorrido = true;
    public float RecorridoTotal = 250;
    public float tiempoTotal = 60;
    public float metrosSegundo;
    public float avance;
    public float tiempoResta;
    float xCurve = 0;
    float yCurve = -15;
    float falloffCurve;
    private float acumulado;
    public GameObject destroyed;
    public Slider sliderRecorrido;
    public GameObject Slider;
    public Slider Vida;
    public GameObject SliderVida;
    float dificultad;
    bool sonido;
    public int nivelActual;
    public AudioSource Fondo;
    public AudioSource SonidoEliminado;
    public int pausa = 1;
    public GameObject PanlePausa;
    public GameObject TutMove;
    public GameObject TutJump;
    public GameObject tutRoll;
    public GameObject TutMovePC;
    public GameObject TutJumpPC;
    public GameObject tutRollPC;
    public int tut = 0;
    public float velocidadAnimacion = 0.5f;

    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IniciarCarrera());
        sliderRecorrido.maxValue = RecorridoTotal;
        tiempoResta = 0;
        
        InvokeRepeating("Angulo", 20, 20);
        Vida.maxValue = jugador.GetComponent<MovimientoPersonaje>().nivelVida;
        dificultad = GameObject.Find("OPCIONES").GetComponent<Opciones>().dificultad;
        sonido = GameObject.Find("OPCIONES").GetComponent<Opciones>().sonido;
        nivelActual = GameObject.Find("OPCIONES").GetComponent<Opciones>().nivelActual;
    }

    // Update is called once per frame
    void Update()
    {
         
        if (iniciar)
        {

            if (pausa == 0 && tut == 0) {

                if (Application.platform == RuntimePlatform.Android)
                {
                    TutMove.SetActive(true);
                }
                else {

                    TutMovePC.SetActive(true);
                }
            }

            Vector2 actual = new Vector2(GetComponent<CurveController>().x, GetComponent<CurveController>().y);
            Vector2 cambio = new Vector2(xCurve, yCurve);
            Vector2 resultado = Vector2.Lerp(actual, cambio, Time.deltaTime/2);
            GetComponent<CurveController>().x = resultado.x;
            GetComponent<CurveController>().y = resultado.y;
            
            /* Control Tiempo restante */
            TimerControl = StartTime - Time.timeSinceLevelLoad + 10 - tiempoResta; //Tiempo Restante
            Debug.Log(tiempoResta);
            string TimerString = (TimerControl.ToString("000"));
            contador.GetComponent<Text>().text = TimerString.ToString();
            


            /*Control metros recorridos */

            platformControl = Time.timeSinceLevelLoad - 10; //Tiempo Actual
            avance = platformControl * metrosSegundo * ( 1 + offset * 100) * pausa;

            if (nivelActual == 3)
            {

                string metros = (avance.ToString("00000"));
                contadorPlataforma.SetActive(true);
                contadorPlataforma.GetComponent<Text>().text = metros.ToString();

            }
            else {

                contador.SetActive(true);
                sliderRecorrido.value = avance;
                Slider.SetActive(true);

            }
            
            Vida.value = jugador.GetComponent<MovimientoPersonaje>().nivelVida;
            SliderVida.SetActive(true);



            //Cambio Velocidad---------------------------------------------------------------------------------------------------------------------------
            
            if (platformControl < 40) {
                Fondo.pitch = 1;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.02f;
                        velocidadAnimacion = 0.5f;
                        ChangeStateSpeed();
                        
                        
                        break;
                    case 2:
                        offset = 0.03f;
                        velocidadAnimacion = 0.6f;
                        ChangeStateSpeed();

                        break;
                    case 3:
                        offset = 0.04f;
                        velocidadAnimacion = 0.7f;
                        ChangeStateSpeed();

                        break;
                }
                
                
            }
            if (platformControl > 40)
            {
                Fondo.pitch = 1.1f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.03f;
                        velocidadAnimacion = 0.6f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.04f;
                        velocidadAnimacion = 0.7f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.05f;
                        velocidadAnimacion = 0.8f;
                        ChangeStateSpeed();
                        break;
                }
                

            }
            if (platformControl > 60)
            {
                Fondo.pitch = 1.2f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.04f;
                        velocidadAnimacion = 0.7f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.05f;
                        velocidadAnimacion = 0.8f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.06f;
                        velocidadAnimacion = 0.9f;
                        ChangeStateSpeed();
                        break;
                }
                

            }
            if (platformControl > 80)
            {
                Fondo.pitch = 1.3f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.05f;
                        velocidadAnimacion = 0.8f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.06f;
                        velocidadAnimacion = 0.9f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.07f;
                        velocidadAnimacion = 1f;
                        ChangeStateSpeed();
                        break;
                }
                

            }
            if (platformControl > 100)
            {
                Fondo.pitch = 1.4f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.06f;
                        velocidadAnimacion = 0.9f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.07f;
                        velocidadAnimacion = 1f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.08f;
                        velocidadAnimacion = 1.1f;
                        ChangeStateSpeed();
                        break;
                }
                

            }
            if (platformControl > 140)
            {
                Fondo.pitch = 1.5f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.07f;
                        velocidadAnimacion = 1f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.08f;
                        velocidadAnimacion = 1.1f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.09f;
                        velocidadAnimacion = 1.2f;
                        ChangeStateSpeed();
                        break;
                }
                

            }
            if (platformControl > 160)
            {
                Fondo.pitch = 1.6f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.08f;
                        velocidadAnimacion = 1.1f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.09f;
                        velocidadAnimacion = 1.2f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.1f;
                        velocidadAnimacion = 1.3f;
                        ChangeStateSpeed();
                        break;
                }
                

            }
            if (platformControl > 180)
            {
                Fondo.pitch = 1.7f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.09f;
                        velocidadAnimacion = 1.2f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.1f;
                        velocidadAnimacion = 1.3f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.11f;
                        velocidadAnimacion = 1.4f;
                        ChangeStateSpeed();
                        break;
                }


            }
            if (platformControl > 200)
            {
                Fondo.pitch = 1.8f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.1f;
                        velocidadAnimacion = 1.3f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.11f;
                        velocidadAnimacion = 1.4f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.12f;
                        velocidadAnimacion = 1.5f;
                        ChangeStateSpeed();
                        break;
                }


            }
            if (platformControl > 220)
            {
                Fondo.pitch = 1.9f;
                switch (dificultad)
                {

                    case 1:
                        offset = 0.11f;
                        velocidadAnimacion = 1.4f;
                        ChangeStateSpeed();
                        break;
                    case 2:
                        offset = 0.12f;
                        velocidadAnimacion = 1.5f;
                        ChangeStateSpeed();
                        break;
                    case 3:
                        offset = 0.13f;
                        velocidadAnimacion = 1.6f;
                        ChangeStateSpeed();
                        break;
                }


            }


            acumulado = jugador.GetComponent<MovimientoPersonaje>().acumuladoObstaculos;

            if (nivelActual == 3)
            {
                if (SinVida == true)
                {
                    
                    StartCoroutine(Eliminado());
                }

                


            }
            else {

                if (TimerControl <= 0 || SinVida == true)
                {
                    StartCoroutine(Eliminado());
                }

                if (avance >= (RecorridoTotal + acumulado) && enRecorrido)
                {

                    generadorCentro.GetComponent<InstanciarObstaculos>().InstanciarPlataforma();
                    enRecorrido = false;

                }

            }

            

            foreach (Transform t in recorrido.transform)
            {
                t.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(t.GetComponent<Renderer>().material.mainTextureOffset.x, t.GetComponent<Renderer>().material.mainTextureOffset.y - offset*1.5f * pausa);
                if (t.GetComponent<Renderer>().material.mainTextureOffset.y >= 1)
                {
                    t.GetComponent<Renderer>().material.mainTextureOffset = Vector2.zero;
                }
              
                
            }
            
        }
        
    }
    void Angulo()
    {

        int cambioAngulo = Random.Range(1, 5);
        switch (cambioAngulo)
        {
            case 1:

               
                switch (dificultad)
                {

                    case 1:
                        xCurve = 25;
                        yCurve = -5f;
                        break;
                    case 2:
                        xCurve = 25;
                        yCurve = -15f;
                        break;
                    case 3:
                        xCurve = 25;
                        yCurve = -25f;
                        break;
                }


                break;
            case 2:

                switch (dificultad)
                {

                    case 1:
                        xCurve = -20f;
                        yCurve = -5;
                        break;
                    case 2:
                        xCurve = -20f;
                        yCurve = -15;
                        break;
                    case 3:
                        xCurve = -20f;
                        yCurve = -25;
                        break;
                }
               
                
                
                break;
            case 3:
                switch (dificultad)
                {

                    case 1:
                        xCurve = -25;
                        yCurve = -5;
                        break;
                    case 2:
                        xCurve = -25;
                        yCurve = -15; 
                        break;
                    case 3:
                        xCurve = -25;
                        yCurve = -25;
                        break;
                }
                
                
                
                break;
            case 4:
                switch (dificultad)
                {

                    case 1:
                        xCurve = 20;
                        yCurve = -5;
                        break;
                    case 2:
                        xCurve = 20;
                        yCurve = -15;
                        break;
                    case 3:
                        xCurve = 20;
                        yCurve = -25;
                        break;
                }
                
                
                
                break;



        }
    }
    IEnumerator IniciarCarrera()
    {
        yield return new WaitForSeconds(6);
        imagen3.SetActive(true);
        yield return new WaitForSeconds(1);
        imagen3.SetActive(false);
        imagen2.SetActive(true);
        yield return new WaitForSeconds(1);
        imagen2.SetActive(false);
        imagen1.SetActive(true);
        yield return new WaitForSeconds(1);
        imagen1.SetActive(false);
        imagen0.SetActive(true);
        yield return new WaitForSeconds(1);
        imagen0.SetActive(false);
        iniciar = true;
        jugador.GetComponent<MovimientoPersonaje>().IniciarCarrera = true;
        StartTime = tiempoTotal;
        if (nivelActual == 1) {
            yield return new WaitForSeconds(1);
            pausa = 0;
            PanlePausa.SetActive(true);
            if (Application.platform == RuntimePlatform.Android)
            {
                TutMove.SetActive(true);
                
                    
            }else{

                TutMovePC.SetActive(true);
            }
            
            Time.timeScale = 0;
        }
        
        


    }
    void ChangeStateSpeed()
    {
        jugador.GetComponent<Animator>().SetFloat("VelocidadAnimacion", velocidadAnimacion);
        
    }


    IEnumerator Eliminado()
    {
        Fondo.Stop();
        SonidoEliminado.Play();
        if (nivelActual == 3)
        {
            avance = Mathf.Round(avance * 1000f/1000f);
            switch (dificultad)
            {
                case 1:
                    if (GameObject.Find("OPCIONES").GetComponent<Opciones>().puntuacionTotalEasy < avance) {

                        GameObject.Find("OPCIONES").GetComponent<Opciones>().puntuacionTotalEasy = avance;
                        GameObject.Find("OPCIONES").GetComponent<Opciones>().Guargar();
                    }
                    
                    break;
                case 2:
                    if (GameObject.Find("OPCIONES").GetComponent<Opciones>().puntuacionTotalNormal < avance)
                    {
                        GameObject.Find("OPCIONES").GetComponent<Opciones>().puntuacionTotalNormal = avance;
                        GameObject.Find("OPCIONES").GetComponent<Opciones>().Guargar();
                    }
                    break;
                case 3:
                    if (GameObject.Find("OPCIONES").GetComponent<Opciones>().puntuacionTotalHard < avance)
                    {
                        GameObject.Find("OPCIONES").GetComponent<Opciones>().puntuacionTotalHard = avance;
                        GameObject.Find("OPCIONES").GetComponent<Opciones>().Guargar();
                    }
                    break;
            }

            contador.SetActive(false);
            jugador.GetComponent<MovimientoPersonaje>().IniciarCarrera = false;
            iniciar = false;
            jugador.GetComponent<Animator>().SetTrigger("Eliminado");
            yield return new WaitForSeconds(2);
            destroyed.SetActive(true);
            yield return new WaitForSeconds(4);

            SceneManager.LoadScene("1_MenuPrincipal");

        }
        else {
            contador.SetActive(false);
            jugador.GetComponent<MovimientoPersonaje>().IniciarCarrera = false;
            iniciar = false;
            jugador.GetComponent<Animator>().SetTrigger("Eliminado");
            yield return new WaitForSeconds(2);
            destroyed.SetActive(true);
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene("1_MenuPrincipal");

        }
        
        

    }

    

      public void TutorialMove() {

        if (Application.platform == RuntimePlatform.Android)
        {
            TutMove.SetActive(false);
            TutJump.SetActive(true);
        }else {
            TutMovePC.SetActive(false);
            TutJumpPC.SetActive(true);

        }
                    
            tut = 1;
    
    }
    public void TutorialJump() {
        if (Application.platform == RuntimePlatform.Android)
        {
            TutJump.SetActive(false);
            tutRoll.SetActive(true);
        }
        else {
            TutJumpPC.SetActive(false);
            tutRollPC.SetActive(true);

        }
        tut = 2;
    }
    public void TutorialRoll() {
        if (Application.platform == RuntimePlatform.Android)
        {
            tutRoll.SetActive(false);
            
        }
        else {

            tutRollPC.SetActive(false);
        }
        tut = 3;
        pausa = 1;
        PanlePausa.SetActive(false);
        Time.timeScale = 1;
    }
}
