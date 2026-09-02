using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        IrParaMenu();
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IrParaCutscene()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void IrParaLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void IrParaLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void IrParaLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void IrParaCenaFinal()
    {
        SceneManager.LoadScene("CenaFinal");
    }
}