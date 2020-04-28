using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PosicionPersonaje : MonoBehaviour
{
    public int carril;
    public Vector3 Posicion;
    public AudioSource Mover;
    public GameObject Controlador;

    //ControlAndroid
    //ControlAndroid
    public float minSwipeLength = 5f;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    Vector2 firstClickPos;
    Vector2 secondClickPos;
    

    public static Swipe swipeDirection;

    // Start is called before the first frame update
    void Start()
    {
        carril = 1;
        Posicion = transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        DetectSwipe();
        Debug.Log(carril);
        

        Vector3 cambioPosicion = Vector3.Lerp(transform.position, Posicion, 10 * Time.deltaTime);
        transform.position = new Vector3(cambioPosicion.x, transform.position.y, transform.position.z);
    }
    public void DetectSwipe()
    {

        if (GameObject.Find("Personaje").GetComponent<MovimientoPersonaje>().IniciarCarrera)
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


                }
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                     //swipeDirection = Swipe.Left;
                    Debug.Log("Left");
                            Mover.Play();
                            if (carril != 1)
                            {
                                carril--;
                                Posicion = new Vector3(transform.position.x - 6f, transform.position.y, transform.position.z);
                                
                            }

                    // Swipe right
                }
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    //swipeDirection = Swipe.Right;
                    Debug.Log("right");
                            Mover.Play();
                            if (carril != 3 )
                            {

                                    carril++;
                                    Posicion = new Vector3(transform.position.x + 6f, transform.position.y, transform.position.z);
                                   
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

                }
                else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    //swipeDirection = Swipe.Left;
                    Debug.Log("Left");
                            Mover.Play();
                            
                            if (carril != 1 )
                            {
                                carril--;
                                Posicion = new Vector3(transform.position.x - 6f, transform.position.y, transform.position.z);
                                
                    }
                      // Swipe right
                }
                else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    //SwipeDirection = Swipe.Right;
                    Debug.Log("right");
                            Mover.Play();
                            
                            
                        
                             }

                            if (carril != 3 )
                            {
                                carril++;
                                Posicion = new Vector3(transform.position.x + 6f, transform.position.y, transform.position.z);
                                
                    }
                }


            }

        }
    }
            



    
    

    


