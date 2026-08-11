using UnityEngine;
using UnityEngine.SceneManagement;

public class PortaVitoria : MonoBehaviour
{
    public static bool PodePassar = false;

    [SerializeField] private string proximaFase;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PodePassar)
            {
                Debug.Log("Passando para a próxima fase!");

                SceneManager.LoadScene(proximaFase);
            }
            else
            {
                Debug.Log("Você ainda precisa pegar o objeto de vitória!");
            }
        }
    }
}