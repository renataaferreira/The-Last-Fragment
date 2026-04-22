using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // =========================
    // BOTÃO PLAY
    // =========================
    public void Jogar()
    {
        SceneManager.LoadScene("Cutscene inicial"); 
        // coloque aqui o nome EXATO da sua cena
    }

    // =========================
    // BOTÃO SAIR
    // =========================
    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}