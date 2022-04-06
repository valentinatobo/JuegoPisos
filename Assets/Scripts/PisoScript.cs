using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PisoScript : MonoBehaviour
{
    
    private float min_X = -2.8f, max_X = 2.8f;
    private bool sePuedeMover;
    private int contPisosC =0; 
    private float velocidadMovimiento = 2f;
    private Rigidbody2D miCuerpo;
    private bool gameOver;
    private bool ignoreColision;
    private bool ignorarDisparador;

    void Awake(){
        miCuerpo = GetComponent<Rigidbody2D>();
        miCuerpo.gravityScale = 0f;
    }
    
    // Start is called before the first frame update
    void Start(){
        sePuedeMover = true;

        if(Random.Range(0,2)>0){
            velocidadMovimiento *= 1f;
        }

        GameplayController.instance.pisoActual = this;

    }

    // Update is called once per frame
    void Update()
    {
        MoverPiso();
    }

    void MoverPiso(){
        if(sePuedeMover){
            Vector3 temp = transform.position;

            temp.x += velocidadMovimiento * Time.deltaTime;

            if (temp.x > max_X){
                velocidadMovimiento *= -1f; //Invierte la dirección
            } else if (temp.x < min_X) {
                velocidadMovimiento *= -1f;
            }

            transform.position = temp;

        }
    }

    public void lanzarPiso(){
        sePuedeMover = false;
        miCuerpo.gravityScale = Random.Range(2, 4);
    }

    void AterrizarFallido(){
        if(gameOver){
            return;
        }
        
        this.tag = "pisofuera";
        Destroy(this);

        GameplayController.instance.contVidaGC -=1;
        ignoreColision = true;
        ignorarDisparador = true;

        GameplayController.instance.LanzarNuevaCaja();
 
    }

    void Aterrizar(){

        if(gameOver){
            return;
        }

        
        GameplayController.instance.contPuntajeGC +=1;
        if ((GameplayController.instance.contPuntajeGC % 3)==0 ){
            GameplayController.instance.contMonedasGC +=1;
        }
        
        ignoreColision = true;
        ignorarDisparador = true;

        GameplayController.instance.LanzarNuevaCaja();
        GameplayController.instance.MoverCamara();

    }

    void ReiniciarJuego(){
        GameplayController.instance.ReiniciarJuego();
        
    }

    void OnCollisionEnter2D(Collision2D objetivo){

        if (ignoreColision){
            
            return;
        }

        if (objetivo.gameObject.tag == "Base"){
            contPisosC +=1;
            if (contPisosC !=1){
                return;
            } else{
                Invoke("Aterrizar",2f);
                ignoreColision = true;
            }
            
            
        }

        if (objetivo.gameObject.tag == "Piso"){
            Invoke("Aterrizar",2f);
            ignoreColision = true;
            Debug.Log("piso");
        }

        

    }

    void OnTriggerEnter2D(Collider2D objetivo){
        if (ignorarDisparador){
            return;
        }

        if (objetivo.tag == "GameOver"){
            if (GameplayController.instance.contVidaGC == 0){
                CancelInvoke("Aterrizar");
                CancelInvoke("AterrizarFallido");
                gameOver = true;
                ignorarDisparador = true;
                Invoke("ReiniciarJuego",2f);

            }else{
                CancelInvoke("Aterrizar");
                Invoke("AterrizarFallido",2f);
            }

            


        }
        
        
    }





}
