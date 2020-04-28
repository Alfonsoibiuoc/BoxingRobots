using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class Opciones : MonoBehaviour
{
    public bool nivel1Completado;
    public bool nivel2Completado;
    public bool desbloqueado2;
    public bool desbloqueado3;
    public int nivelActual;
    public float puntuacionTotalEasy;
    public float puntuacionTotalNormal;
    public float puntuacionTotalHard;
    public Text pEasy;
    public Text pNormal;
    public Text pHard;
    public float dificultad;
    public bool sonido;
    private String rutaArchivo;
    private static Opciones objetoOpciones;
    public int plataforma;

    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log(Application.platform);

        rutaArchivo = Application.persistentDataPath + "/boxingRobotsEasy.dat";
        DontDestroyOnLoad(this);

        if (objetoOpciones == null)
        {
            objetoOpciones = this;

        }
        else {
            DestroyObject(gameObject);
            
        }

        
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        


    }

    void Start()
    {
        Cargar();
        nivelActual = 1;
        dificultad = 1;
        sonido = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sonido == true)
        {

            AudioListener.volume = 1;
        }
        else {

            AudioListener.volume = 0;
        }
        //Debug.Log(Application.persistentDataPath);
    }

    public void Cargar() {

        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);
            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);
            puntuacionTotalEasy = datos.puntuacionMaximaEasy;
            puntuacionTotalNormal = datos.puntuacionMaximaNormal;
            puntuacionTotalHard = datos.puntuacionMaximaHard;
            nivel1Completado = datos.nivel1Comp;
            nivel2Completado = datos.nivel2Comp;
            desbloqueado2 = datos.desb2;
            desbloqueado3 = datos.desb3;

            file.Close();

            pEasy.text = puntuacionTotalEasy.ToString();
            pNormal.text = puntuacionTotalNormal.ToString();
            pHard.text = puntuacionTotalHard.ToString();

        }
        else {
            puntuacionTotalEasy = 0;
            puntuacionTotalNormal = 0;
            puntuacionTotalHard = 0;
            nivel1Completado = false;
            nivel2Completado = false;
            desbloqueado2 = false;
            desbloqueado3 = false;

            pEasy.text = puntuacionTotalEasy.ToString();
            pNormal.text = puntuacionTotalEasy.ToString();
            pHard.text = puntuacionTotalEasy.ToString();


        }
        


    }

    public void Guargar() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);
        DatosAGuardar datos = new DatosAGuardar();
        datos.puntuacionMaximaEasy = puntuacionTotalEasy;
        datos.puntuacionMaximaNormal = puntuacionTotalNormal;
        datos.puntuacionMaximaHard = puntuacionTotalHard;
        datos.nivel1Comp = nivel1Completado;
        datos.nivel2Comp = nivel2Completado;
        datos.desb2 = desbloqueado2;
        datos.desb3 = desbloqueado3;
        bf.Serialize(file, datos);
        file.Close();

    }

    


}
[Serializable]
class DatosAGuardar {

    public float puntuacionMaximaEasy;
    public float puntuacionMaximaNormal;
    public float puntuacionMaximaHard;
    public bool nivel1Comp;
    public bool nivel2Comp;
    public bool desb2;
    public bool desb3;




}
