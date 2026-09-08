using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public float tempo = 5f;

    private void Start()
    {
        Invoke(nameof(IrParaLevel1), tempo);
    }

    private void IrParaLevel1()
    {
        GameManager.Instance.IrParaLevel1();
    }
}
