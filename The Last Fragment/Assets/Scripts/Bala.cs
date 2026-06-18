using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade = 10f;
    public int danoDaBala = 10;

    private Rigidbody2D rb;
    private Transform alvoBoss;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Procura na cena por um GameObject que tenha a Tag "Inimigo"
        GameObject inimigo = GameObject.FindWithTag("Inimigo");

        if (inimigo != null)
        {
            alvoBoss = inimigo.transform;

            // Calcula a direção: Posição do Boss menos a posição da Bala
            Vector2 direcao = (alvoBoss.position - transform.position).normalized;

            // Aplica a velocidade na direção exata do Boss
            rb.linearVelocity = direcao * velocidade;

            // (Opcional) Faz a bala girar para "olhar" na direção do Boss
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        }
        else
        {
            // Se o Boss já morreu ou não foi encontrado, a bala vai reto para a direita
            rb.linearVelocity = Vector2.right * velocidade;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Acertou: " + collision.name);

        if (collision.CompareTag("Inimigo"))
        {
            VidaBoss vidaDoBoss = collision.GetComponent<VidaBoss>();

            if (vidaDoBoss != null)
            {
                vidaDoBoss.TomarDanoBoss(danoDaBala);
            }
        }

        Destroy(gameObject);
    }
}