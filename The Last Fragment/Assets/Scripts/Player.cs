using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 10f;

    public Transform groundCheck;
    public float raioCheck = 0.2f;
    public LayerMask layerChao;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float movimento;
    private bool noChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimento
        movimento = Input.GetAxisRaw("Horizontal");

        // Virar personagem
        if (movimento > 0)
            sr.flipX = false;
        else if (movimento < 0)
            sr.flipX = true;

        // Verificar chão
        noChao = Physics2D.OverlapCircle(groundCheck.position, raioCheck, layerChao);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);
    }
}