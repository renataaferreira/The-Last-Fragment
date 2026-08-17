using UnityEngine;

public class ObjetoVitoria : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Objeto de vitória coletado!");

            PortaVitoria.PodePassar = true;

            Destroy(gameObject);
        }
    }
}