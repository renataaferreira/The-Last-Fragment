using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.right * velocidade;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}