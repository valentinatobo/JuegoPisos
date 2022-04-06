using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuprincipal : MonoBehaviour
{


    public Slider efectos;
    public AudioSource efSource;
    public AudioClip clickSound;
    private float lastVolume;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        

    public void escenasaludo(){
        SceneManager.LoadScene("saludo");
        PlaySoundButton();
        
    }

    public void escenajuego(){
        SceneManager.LoadScene("SampleScene");
        PlaySoundButton();
    }

    public void escenacreditos(){
        SceneManager.LoadScene("gano");
        
    }

    public void escenaconf(){
        SceneManager.LoadScene("configuraciones");
        PlaySoundButton();
        
    }

    public void escenaperdio(){
        SceneManager.LoadScene("perder");
    }

    public void escenagano(){
        SceneManager.LoadScene("creditoos");
        PlaySoundButton();
        
    }

    public void volvermenu(){
        SceneManager.LoadScene("menu");
        PlaySoundButton();
        
    }

    public void volverajugar(){
        SceneManager.LoadScene("SampleScene");
        PlaySoundButton();                 
        
    }

    public void salir(){
        Application.Quit();
        PlaySoundButton();
    }

    public void PlaySoundButton()
    {
        efSource.PlayOneShot(clickSound);
    }
}
