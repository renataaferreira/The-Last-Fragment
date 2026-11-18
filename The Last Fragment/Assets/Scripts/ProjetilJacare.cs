using UnityEngine;

public class ProjetilJacare : MonoBehaviour
{
    public float velocidade = 10f;
    public int danoDaBala = 10;

    private Rigidbody2D rb;
    private Transform alvoBoss;

    public Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = direction.normalized * velocidade;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            VidaPlayer vida = collision.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                vida.TomarDano(danoDaBala);
            }

            Destroy(gameObject);
        }
        else if(collision.CompareTag("Chao"))
        {
            Destroy(gameObject);
        }

    }
}