using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public Text puntaje, vida, monedas; 
    public int contPuntajeGC, contVidaGC=3, contMonedasGC=0;
    public static GameplayController instance;

    public PisoSpawner piso_Spawner;

    [HideInInspector]
    public PisoScript pisoActual;

    public CameraMovement cameraScript;
    private int contadorMovimiento;



    void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        piso_Spawner.SpawnPiso();
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
        puntaje.text = "Puntaje: " + contPuntajeGC ;
        vida.text = ""+ contVidaGC;
        monedas.text = ""+ contMonedasGC;
        if(contPuntajeGC==8){
            GanarNivelUno();
        }

        //GameObject.FindWithTag("Base").position;
    }

    void DetectInput(){
        if(Input.GetMouseButtonDown(0)){
            pisoActual.lanzarPiso();
            
        }
    }

    public void LanzarNuevaCaja(){
        Invoke("NuevoPiso", 2f);
    }

    void NuevoPiso(){
        piso_Spawner.SpawnPiso();

    }

    public void MoverCamara(){
        contadorMovimiento++;
        if(contadorMovimiento == 2){
            contadorMovimiento = 0;
            cameraScript.targetPos.y += 3f;
        }
    }

    public void GanarNivelUno(){
        SceneManager.LoadScene("creditoos");
    }
    public void ReiniciarJuego(){
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(
    //         UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
    //     );
        SceneManager.LoadScene("perder");
    }

}
