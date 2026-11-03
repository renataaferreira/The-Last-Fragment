using UnityEngine;

public class ColetarMoeda : MonoBehaviour
{
    public int valorMoeda = 1;

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (!outro.CompareTag("Player"))
        {
            return;
        }

        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager não encontrado!");
            return;
        }

        GameManager.Instance.AdicionarMoedas(valorMoeda);

        Debug.Log("Moeda coletada! Valor: " + valorMoeda);

        Destroy(gameObject);
    }
}