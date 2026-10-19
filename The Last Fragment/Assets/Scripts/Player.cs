using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 10f;

    private Rigidbody2D rb;
    private Transform checkpointAtual;
    private SpriteRenderer sr;
    private Animator animator;

    [Header("Tiro")]
    public GameObject balaPrefab;
    public Transform pontoDisparo;
    private bool podeAtirar = false;

    [Header("Animações")]
    private bool estaNoChao = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (rb == null)
            Debug.LogError("Player precisa de um Rigidbody2D!");

        if (sr == null)
            Debug.LogError("Player precisa de um SpriteRenderer!");

        if (animator == null)
            Debug.LogError("Player precisa de um Animator!");
    }

    void Update()
    {
        if (rb == null)
            return;

        if (Keyboard.current == null)
            return;

        // =========================
        // MOVIMENTO
        // =========================
        float movimento = 0f;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            movimento = -1f;

            if (sr != null)
                sr.flipX = true;
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            movimento = 1f;

            if (sr != null)
                sr.flipX = false;
        }

        rb.linearVelocity = new Vector2(
            movimento * velocidade,
            rb.linearVelocity.y
        );

        // =========================
        // ANIMAÇÃO IDLE E RUN
        // =========================
        if (animator != null)
        {
            animator.SetBool("isRunning", movimento != 0f);
            animator.SetBool("isGrounded", estaNoChao);
        }

        // =========================
        // PULO
        // =========================
        if (Keyboard.current.spaceKey.wasPressedThisFrame
            && estaNoChao)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );

            estaNoChao = false;

            if (animator != null)
            {
                animator.SetBool("isGrounded", false);
                animator.SetTrigger("Jump");
            }
        }

        // =========================
        // ATACAR / ATIRAR COM F
        // =========================
        if (podeAtirar &&
            Keyboard.current.fKey.wasPressedThisFrame)
        {
            if (animator != null)
                animator.SetTrigger("Attack");

            if (balaPrefab != null && pontoDisparo != null)
            {
                Instantiate(
                    balaPrefab,
                    pontoDisparo.position,
                    Quaternion.identity
                );
            }
            else
            {
                Debug.LogWarning(
                    "Configure Bala Prefab e Ponto Disparo no Inspector."
                );
            }
        }

        // =========================
        // CAIU DO MAPA
        // =========================
        if (transform.position.y < -5f)
        {
            Respawn();
        }
    }

    // =========================
    // DETECTAR O CHÃO
    // =========================
    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contato in collision.contacts)
        {
            if (contato.normal.y > 0.5f)
            {
                estaNoChao = true;
                return;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        estaNoChao = false;
    }

    // =========================
    // LIBERAR TIRO
    // =========================
    public void LiberarTiro()
    {
        podeAtirar = true;
    }

    // =========================
    // CHECKPOINT
    // =========================
    public void SetCheckpoint(Transform novoCheckpoint)
    {
        checkpointAtual = novoCheckpoint;
    }

    public void Respawn()
    {
        if (checkpointAtual != null)
        {
            transform.position = checkpointAtual.position;
        }

        rb.linearVelocity = Vector2.zero;
        estaNoChao = false;

        if (animator != null)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isGrounded", false);
            animator.ResetTrigger("Jump");
            animator.ResetTrigger("Attack");
        }
    }
}