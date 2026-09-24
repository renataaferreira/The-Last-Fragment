using UnityEngine;

public class MenuControles : MonoBehaviour
{
    public void Jogar()
    {
        GameManager.Instance.IrParaCutscene();
    }

    public void AbrirConfiguracoes()
    {
        GameManager.Instance.IrParaConfiguracoes();
    }
}