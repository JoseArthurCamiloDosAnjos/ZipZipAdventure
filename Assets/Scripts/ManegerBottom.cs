using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManegerBottom : MonoBehaviour
{
    public void ReiniciarFase()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

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