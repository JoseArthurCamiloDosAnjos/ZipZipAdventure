using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int valor = 1;

    [Header("Som")]
    [SerializeField] private AudioClip somMoeda;
    [SerializeField] [Range(0f, 1f)] private float volume = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Atualiza o contador
            CoinController.Instance.AdicionarMoeda(valor);

            // Toca o som
            if (somMoeda != null)
            {
                AudioSource.PlayClipAtPoint(somMoeda, Camera.main.transform.position, volume);
            }

            // Remove a moeda
            Destroy(gameObject);
        }
    }
}