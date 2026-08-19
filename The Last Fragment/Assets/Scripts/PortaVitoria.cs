using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaVitoria : MonoBehaviour
{
    public static bool PodePassar = false;

    [SerializeField] private string proximaFase = "Level 2";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PodePassar)
            {
                Debug.Log("Indo para a Level 2!");

                SceneManager.LoadScene(proximaFase);
            }
            else
            {
                Debug.Log("Você precisa pegar o fragmento!");
            }
        }
    }
}