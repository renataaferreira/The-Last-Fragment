using UnityEngine;

public class ConfiguracoesManager : MonoBehaviour
{
    public void Voltar()
    {
        GameManager.Instance.IrParaMenu();
    }

    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }
}