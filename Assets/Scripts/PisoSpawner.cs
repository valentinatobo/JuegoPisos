using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoSpawner : MonoBehaviour
{

    public GameObject piso_Prefab;
    public GameObject piso_uno_Prefab;
    public GameplayController instance;

    void Start() {
        
    }


    public void SpawnPiso(){
        if (GameplayController.instance.contPuntajeGC == 0){
            GameObject piso_Obj = Instantiate(piso_uno_Prefab);
            Vector3 temp = transform.position;
            temp.z = 0f;
            piso_Obj.transform.position = temp;
            
        }else{

        GameObject piso_Obj = Instantiate(piso_Prefab);

        Vector3 temp = transform.position;
        temp.z = 0f;

        piso_Obj.transform.position = temp;
        }

    }

    
}
