
using UnityEngine;

public class MiniBossMovimento : MonoBehaviour
{
    public float velocidade = 2f;
    public float distancia = 3f;

    private Vector3 posicaoInicial;
    private int direcao = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        posicaoInicial = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimenta o mini boss para a esquerda e direita
        transform.position += Vector3.right * direcao * velocidade * Time.deltaTime;

        // Verifica se chegou ao limite direito
        if (transform.position.x >= posicaoInicial.x + distancia)
        {
            direcao = -1;
        }

        // Verifica se chegou ao limite esquerdo
        if (transform.position.x <= posicaoInicial.x - distancia)
        {
            direcao = 1;
        }

        // Vira o personagem conforme a direção
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = direcao < 0;
        }
    }
}
