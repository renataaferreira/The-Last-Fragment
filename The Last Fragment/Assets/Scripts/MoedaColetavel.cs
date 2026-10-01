
using UnityEngine;

public class MoedaColetavel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (ContadorMoedas.Instancia == null)
        {
            Debug.LogError("ContadorMoedas não foi criado ou não está ativo na cena!");
            return;
        }

        ContadorMoedas.Instancia.ColetarMoeda();

        Destroy(gameObject);
    }
}