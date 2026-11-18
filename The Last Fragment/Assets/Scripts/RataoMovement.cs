using System.Collections;
using UnityEngine;
using System;

public class RataoMovement : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sprite;
    private Transform player => GameObject.Find("Player").GetComponent<Transform>();
    [SerializeField] private AtaqueRato ataque;

    [Header("Limites da arena")]
    [SerializeField] private Transform limiteEsquerdo;
    [SerializeField] private Transform limiteDireito;

    [Header("Movimentação")]
    [SerializeField] private float velocidade = 2f;
    [SerializeField] private float areaDeteccao = 6f;

    private int direcaoPatrulha = 1;
    private bool perseguindo = false;
    private bool aguardandoNovaDeteccao = false;

    private float limiteMin;
    private float limiteMax;

    private void Start()
    {
        limiteMin = Mathf.Min(
            limiteEsquerdo.position.x,
            limiteDireito.position.x
        );

        limiteMax = Mathf.Max(
            limiteEsquerdo.position.x,
            limiteDireito.position.x
        );
    }

    private void FixedUpdate()
    {
        // Atualiza a detecção
        float distancia = Vector2.Distance(
            transform.position,
            player.position
        );

        bool playerDetectado = distancia <= areaDeteccao;

        // Espera o player sair da área para permitir
        // uma nova perseguição
        if (aguardandoNovaDeteccao && !playerDetectado)
        {
            aguardandoNovaDeteccao = false;
        }

        // Não inicia perseguição se estiver bloqueado
        if (!perseguindo &&
            !aguardandoNovaDeteccao &&
            playerDetectado)
        {
            perseguindo = true;
        }

        // Não movimenta durante o ataque
        if (ataque.isAttacking)
            return;

        if (perseguindo)
        {
            Perseguir();
        }
        else
        {
            Patrulhar();
        }
    }

    private void Perseguir()
    {
        float posX = rb.position.x;
        float playerX = player.position.x;

        // Verifica se chegou ao limite na direção do player
        bool chegouNoLimite =
            (playerX > posX && posX >= limiteMax - 0.02f) ||
            (playerX < posX && posX <= limiteMin + 0.02f);

        // Player saiu da área ou boss chegou ao limite
        if (Vector2.Distance(transform.position, player.position)
                > areaDeteccao || chegouNoLimite)
        {
            perseguindo = false;
            aguardandoNovaDeteccao = true;
            return;
        }

        Mover(playerX);
    }

    private void Patrulhar()
    {
        float destino = direcaoPatrulha == 1
            ? limiteMax
            : limiteMin;

        Mover(destino);

        // Inverte a direção ao alcançar o limite
        if (Mathf.Abs(rb.position.x - destino) < 0.02f)
        {
            direcaoPatrulha *= -1;
        }
    }

    private void Mover(float destinoX)
    {
        float novaPosX = Mathf.MoveTowards(
            rb.position.x,
            destinoX,
            velocidade * Time.fixedDeltaTime
        );

        novaPosX = Mathf.Clamp(novaPosX, limiteMin, limiteMax);

        rb.MovePosition(
            new Vector2(novaPosX, rb.position.y)
        );

        // Flip do sprite
        float direcao = destinoX - rb.position.x;

        if (direcao > 0.01f)
            sprite.flipX = true;
        else if (direcao < -0.01f)
            sprite.flipX = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (limiteEsquerdo == null || limiteDireito == null)
            return;

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(
            limiteEsquerdo.position,
            limiteDireito.position
        );

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            areaDeteccao
        );
    }
}
