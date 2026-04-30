using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 10f;

    private Rigidbody2D rb;

    private Transform checkpointAtual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimento = 0;

        if (Keyboard.current.leftArrowKey.isPressed)
            movimento = -1;
        else if (Keyboard.current.rightArrowKey.isPressed)
            movimento = 1;

        rb.linearVelocity = new Vector2(movimento * velocidade, rb.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
        }

        // Caiu do mapa
        if (transform.position.y < -5)
        {
            Respawn();
        }
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
    }
}