using UnityEngine;

public class MenuControles : MonoBehaviour
{
    public void Jogar()
    {
        GameManager.Instance.IrParaCutscene();
    }
}