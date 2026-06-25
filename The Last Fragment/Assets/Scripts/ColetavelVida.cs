using UnityEngine;

public class ColetavelVida : MonoBehaviour
{
    public int quantidadeVida = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            VidaPlayer vida = collision.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                vida.RecuperarVida(quantidadeVida);
                Destroy(gameObject);
            }
        }
    }
}