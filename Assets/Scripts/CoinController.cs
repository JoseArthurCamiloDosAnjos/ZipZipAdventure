using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public static CoinController Instance;

    [Header("Imagem onde será mostrado o número")]
    public Image numeroImagem;

    [Header("Sprites dos números (0,1,2,3...)")]
    public Sprite[] numeros;

    [Header("Quantidade inicial")]
    public int moedas = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AtualizarHUD();
    }

    public void AdicionarMoeda(int quantidade = 1)
    {
        moedas += quantidade;

        if (moedas >= numeros.Length)
            moedas = numeros.Length - 1;

        AtualizarHUD();
    }

    public void RemoverMoeda(int quantidade = 1)
    {
        moedas -= quantidade;

        if (moedas < 0)
            moedas = 0;

        AtualizarHUD();
    }

    private void AtualizarHUD()
    {
        numeroImagem.sprite = numeros[moedas];
    }

    public int GetMoedas()
    {
        return moedas;
    }

    public void ResetarMoedas()
    {
        moedas = 0;
        AtualizarHUD();
    }
}