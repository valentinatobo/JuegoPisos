using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [HideInInspector]
    public Vector3 targetPos;

    private float movimientoSuave = 1f;

    void Start(){
        targetPos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, movimientoSuave * Time.deltaTime);
    }
}
