using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class puntaje : MonoBehaviour
{

    public static GameplayController instance;
    public Text txtPuntajeFinal ; 

    // Start is called before the first frame update
    void Start()
    {
        ActualizarPuntaje();
    }

    void ActualizarPuntaje(){
        txtPuntajeFinal.text = "Tu puntaje es: " + GameplayController.instance.contPuntajeGC;
    }
    // Update is called once per frame
    void Update()
    {

        
    }
}
