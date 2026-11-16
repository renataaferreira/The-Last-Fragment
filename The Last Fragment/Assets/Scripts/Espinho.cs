using UnityEngine;

public class Espinho : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 10f;
    public int dano;

    public float tempoVida = 4f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * speed;

        Destroy(gameObject, tempoVida);
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.CompareTag("Player"))
        {
            VidaPlayer vida = outro.GetComponentInParent<VidaPlayer>();
            vida.TomarDano(dano);
            Destroy(gameObject);
        }
        
    }
}