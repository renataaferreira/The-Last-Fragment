
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaVitoria : MonoBehaviour
{
    public static bool PodePassar = false;

    [SerializeField] private string proximaFase = "Level 2";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Objeto entrou na porta: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detectado!");

            if (PodePassar)
            {
                Debug.Log("Indo para " + proximaFase + "!");

                SceneManager.LoadScene(proximaFase);
            }
            else
            {
                Debug.Log("Você precisa pegar o fragmento!");
            }
        }
    }
}

