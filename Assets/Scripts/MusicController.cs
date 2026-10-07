using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    public AudioClip musica;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = musica;
        audioSource.loop = true;   // Faz a música repetir
        audioSource.Play();
    }
}