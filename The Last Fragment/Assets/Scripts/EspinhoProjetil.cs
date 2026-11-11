using UnityEngine;

public class EspinhoProjetil : MonoBehaviour
{
    public float velocidade = 8f;
    public int dano = 10;
    public float tempoVida = 4f;

    private Vector2 direcao;

    public void Configurar(Vector2 novaDirecao)
    {
        direcao = novaDirecao.normalized;
    }

    private void Update()
    {
        transform.Translate(
            direcao * velocidade * Time.deltaTime,
            Space.World
        );
    }

    private void Start()
    {
        Destroy(gameObject, tempoVida);
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        VidaPlayer vida = outro.GetComponentInParent<VidaPlayer>();

        if (vida != null)
        {
            vida.TomarDano(dano);
            Destroy(gameObject);
        }
    }
}