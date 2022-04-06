using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayControllerDos : MonoBehaviour
{
    public Text puntaje, vida, monedas; 
    public static GameplayController instance;
    public int contPuntajeGCD, contVidaGCD, contMonedasGCD;

    public PisoSpawner piso_SpawnerD;

    [HideInInspector]
    public PisoScript pisoActualD;

    public CameraMovement cameraScript;
    private int contadorMovimientoD;



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
        puntaje.text = "Puntaje: " + contPuntajeGCD ;
        
        vida.text = ""+ contVidaGCD;
       
        monedas.text = ""+ contMonedasGCD;
        

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
        contadorMovimientoD++;
        if(contadorMovimientoD == 2){
            contadorMovimientoD = 0;
            cameraScript.targetPos.y += 2f;
        }
    }

    public void GanarNivelDos(){
        SceneManager.LoadScene("creditoos");
    }
    public void ReiniciarJuego(){
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(
    //         UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
    //     );
        SceneManager.LoadScene("perder");
    }

}
