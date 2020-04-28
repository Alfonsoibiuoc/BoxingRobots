using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlIntro : MonoBehaviour
{
    public GameObject explosion1;
    public GameObject explosion2;
    public GameObject explosion3;
    public GameObject explosion4;
    public GameObject explosion5;
    public GameObject robot1;
    public GameObject robot2;
    public GameObject robot3;
    public AudioSource Explosion;

    Animator anim1;
    Animator anim2;
    Animator anim3;

    // Start is called before the first frame update

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void Start()
    {
        StartCoroutine(Secuencia());
        anim1 = robot1.GetComponent<Animator>();
        anim2 = robot2.GetComponent<Animator>();
        anim3 = robot3.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
    }

    IEnumerator Secuencia() {

        yield return new WaitForSeconds(59);
        explosion1.SetActive(true);
        
        Explosion.Play();
        anim1.SetTrigger("Explosion");
        Explosion.Play();
        anim2.SetTrigger("Explosion");
        Explosion.Play();
        anim3.SetTrigger("Explosion");
        GameObject.Find("TV").AddComponent<Rigidbody>();
        GameObject.Find("Cube1").AddComponent<Rigidbody>();
        
        GameObject.Find("TV3").AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1);
        Explosion.Play();
        
        yield return new WaitForSeconds(1);
        explosion2.SetActive(true);
        Explosion.Play();
        yield return new WaitForSeconds(1.5f);
        Explosion.Play();
        GameObject.Find("Cube2").AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2.5f);
        explosion3.SetActive(true);
        Explosion.Play();
        GameObject.Find("Cube3").AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2);
        explosion4.SetActive(true);
        Explosion.Play();
        GameObject.Find("TV2").AddComponent<Rigidbody>();
        GameObject.Find("Cube4").AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2);
        explosion5.SetActive(true);
        GameObject.Find("Cube6").AddComponent<Rigidbody>();

        Explosion.Play();
        GameObject.Find("Cube5").AddComponent<Rigidbody>();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("1_MenuPrincipal");


    }

    public void saltar(){

        SceneManager.LoadScene("1_MenuPrincipal");
    }
}
