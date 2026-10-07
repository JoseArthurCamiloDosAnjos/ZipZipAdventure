using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Nome da cena do jogo")]
    public string nomeDaCena = "Game";

    // Botão Jogar
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    // Botão Sair
    public void Sair()
    {
        Debug.Log("Fechando o jogo...");

        // Funciona apenas no jogo compilado
        Application.Quit();

        // Fecha o Play Mode dentro do Editor da Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}