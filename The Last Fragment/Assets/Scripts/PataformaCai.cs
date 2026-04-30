using UnityEngine;

public class PlataformaCai : MonoBehaviour
{
    public float tempoParaCair = 0.5f;
    public float tempoParaVoltar = 3f;

    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer sr;

    private Vector3 posicaoInicial;
    private bool ativada = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        posicaoInicial = transform.position;

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !ativada)
        {
            ativada = true;
            Invoke("Cair", tempoParaCair);
        }
    }

    void Cair()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Invoke("ResetarPlataforma", tempoParaVoltar);
    }

    void ResetarPlataforma()
    {
        // "desaparece"
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = posicaoInicial;

        col.enabled = false;
        sr.enabled = false;

        Invoke("AtivarPlataforma", 1f);
    }

    void AtivarPlataforma()
    {
        col.enabled = true;
        sr.enabled = true;

        ativada = false;
    }
    
}