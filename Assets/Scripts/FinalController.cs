using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(AudioSource))]
public class FinalController : MonoBehaviour
{
    [Header("Configurações")]
    public string playerTag = "Player";

    [Header("Objeto de Vitória")]
    public GameObject objetoParaAtivar;

    [Header("Painel Game Over")]
    public GameObject painelGameOver;

    [Header("Sons")]
    public AudioClip somParabens;
    public AudioClip somGameOver;

    [Header("Tempo até finalizar")]
    public float tempoParaFinalizar = 3f;


    private AudioSource audioSource;
    private bool finalizado = false;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        // Continua tocando mesmo com Time.timeScale = 0
        audioSource.ignoreListenerPause = true;


        if (objetoParaAtivar != null)
            objetoParaAtivar.SetActive(false);


        if (painelGameOver != null)
            painelGameOver.SetActive(false);
    }



    // ==========================
    // VITÓRIA
    // ==========================

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finalizado)
            return;


        if (other.CompareTag(playerTag))
        {
            finalizado = true;


            // Para música da fase
            PararMusicas();


            // Ativa objeto de vitória
            if (objetoParaAtivar != null)
                objetoParaAtivar.SetActive(true);



            // Toca música de vitória
            if (somParabens != null)
            {
                audioSource.clip = somParabens;
                audioSource.loop = false;
                audioSource.Play();
            }



            // Desativa jogador
            Player player = other.GetComponent<Player>();

            if (player != null)
                player.enabled = false;



            Invoke(nameof(FinalizarFase), tempoParaFinalizar);
        }
    }



    private void FinalizarFase()
    {
        Debug.Log("Fase concluída!");

        Time.timeScale = 0f;
    }



    // ==========================
    // GAME OVER
    // ==========================

    public void GameOver(Player player)
    {
        if (finalizado)
            return;


        finalizado = true;


        // Para música da fase
        PararMusicas();



        if (player != null)
            player.enabled = false;



        Invoke(nameof(MostrarGameOver), tempoParaFinalizar);
    }



    private void MostrarGameOver()
    {

        // Mostra painel
        if (painelGameOver != null)
            painelGameOver.SetActive(true);



        // Toca som de Game Over
        if (somGameOver != null)
        {
            audioSource.clip = somGameOver;
            audioSource.loop = false;
            audioSource.Play();
        }



        Time.timeScale = 0f;
    }



    // ==========================
    // ÁUDIO
    // ==========================

    private void PararMusicas()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            if (audio != audioSource)
            {
                audio.Stop();
            }
        }
    }



    // ==========================
    // BOTÕES
    // ==========================

    public void ReiniciarFase()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }



    public void ProximaFase()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }



    public void MenuPrincipal()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}