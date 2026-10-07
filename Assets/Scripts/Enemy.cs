using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Tipo de Inimigo")]
    public bool IsFly;


    [Header("Movimento")]
    public float speed = 4f;


    [Header("Patrulha (Terrestre)")]
    public float distanciaPatrulha = 5f;

    private Vector3 pontoInicial;
    private int direction = 1;
    [Header("Patrulha(Voador)")]
    private int verticalDirection = 1;


    private SpriteRenderer sprite;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        // Guarda o local onde o inimigo nasceu
        pontoInicial = transform.position;
    }


    void Update()
    {
        if (IsFly)
        {
            Voador();
        }
        else
        {
            Terrestre();
        }
    }


    void Terrestre()
    {
        // Movimento horizontal
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);


        // Limite da patrulha
        float distancia = transform.position.x - pontoInicial.x;


        if (distancia >= distanciaPatrulha)
        {
            direction = -1;
        }
        else if (distancia <= -distanciaPatrulha)
        {
            direction = 1;
        }


        Flip();
    }


    void Voador()
    {
        // Movimento vertical
        transform.Translate(Vector2.up * speed * verticalDirection * Time.deltaTime);


        // Limite de altura
        float distancia = transform.position.y - pontoInicial.y;


        if (distancia >= distanciaPatrulha)
        {
            verticalDirection = -1;
        }
        else if (distancia <= -distanciaPatrulha)
        {
            verticalDirection = 1;
        }
    }


    void Flip()
    {
        if (sprite != null)
        {
            sprite.flipX = direction > 0;
        }
    }
}