using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //Patrón Singleton
    public static AudioManager instance;

    //AudioSource (el altavoz que reproducirá el sonido)
    [Tooltip("Referencia al Audio Source de los pasos")]
    [SerializeField] private AudioSource footstepsAudioSource;

    [Tooltip("Referencia al Audio Source de la música de fondo")]
    [SerializeField] private AudioSource BGMAudioSource;

    [Tooltip("Referencia al Audio Source de la música de fondo del menu")]
    [SerializeField] private AudioSource menuAudioSource;



    //AudioClip (clip de audio que reproducirá el altavoz, recuerda usar .wav)
    [Tooltip("Referencia al Audio Clip de los pasos")]
    [SerializeField] private AudioClip stepAudioClip;

    [Tooltip("Referencia al Audio Clip de la música de fondo")]
    [SerializeField] private AudioClip musicBFMAudioClip;

    [Tooltip("Referencia al Audio Clip de la música de fondo del menu")]
    [SerializeField] private AudioClip musicMenuAudioClip;

    [Tooltip("Referencia al Audio Clip de la música de disparo")]
    [SerializeField] private AudioClip DisparoClip;

    [Tooltip("Referencia al Audio Clip de la música de disparo")]
    [SerializeField] private AudioClip CarneClip;

    [Tooltip("Referencia al Audio Clip de la música de disparo")]
    [SerializeField] private AudioClip BotiquinClip;

    private void Awake()
    {
        if (instance == null)
        {
            //guardamos el audio manager en esta misma variable para su uso global

            instance = this;
            //cuando haya cambio de escenas que no se destruya
            //los audiosources tienen que ser hijos de audiomanager para no ser destruidos
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public static void PlayFootStepSound()
    {

        //Efecto de sonido para los pasos
        //Si el audio no se esta reproduciendo que lo haga
        if (!instance.footstepsAudioSource.isPlaying)
        {
            //Cambiamos el pitch para que no sea repetitivo, el rango debe ser pequeño 
            instance.footstepsAudioSource.pitch = Random.Range(0.5f, 1.5f);
            instance.footstepsAudioSource.Play();

        }

    }

    //Sonido al recoger un objeto por ejemplo con otro altavoz
    public static void PlayBGMSound()
    {

        if (!instance.BGMAudioSource.isPlaying)
        {
            instance.BGMAudioSource.clip = instance.musicBFMAudioClip;
            instance.BGMAudioSource.Play();
            instance.menuAudioSource.Stop();
        }
    }

    //Funcion para cambiar el audio entre escenas
    public static void PlayMainMenuMusic()
    {

        if (!instance.menuAudioSource.isPlaying)
        {
            instance.menuAudioSource.clip = instance.musicMenuAudioClip;
            instance.BGMAudioSource.Stop();
            instance.menuAudioSource.Play();
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorSonido.Instance.EjecutarSonido(CarneClip);
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            ControladorSonido.Instance.EjecutarSonido(BotiquinClip);
            Destroy(gameObject);
        }
    }


}


