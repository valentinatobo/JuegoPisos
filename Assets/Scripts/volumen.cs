using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class volumen : MonoBehaviour
{

    public Slider volumenFondo;
    public Slider efectos;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource efSource;
    public AudioClip clickSound;
    private float lastVolume;

    private void Awake()
    {
        
        volumenFondo.onValueChanged.AddListener(cambiarVolumen);
        efectos.onValueChanged.AddListener(cambiarVolumenEfec);
    }
    
    public void cambiarVolumen(float v){
        mixer.SetFloat("VolumenMus", v);
    }

    public void cambiarVolumenEfec(float v){
        mixer.SetFloat("VolumenEfec", v);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
