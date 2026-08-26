using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        Cutscene,
        Menu,
        Gameplay,
        Final
    }

    public GameState estadoAtual;

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

    public void IrParaCutsceneInicial()
    {
        estadoAtual = GameState.Cutscene;
        SceneManager.LoadScene("CutsceneInicial");
    }

    public void IrParaMenu()
    {
        estadoAtual = GameState.Menu;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IrParaLevel1()
    {
        estadoAtual = GameState.Gameplay;
        SceneManager.LoadScene("Level 1");
    }

    public void IrParaLevel2()
    {
        estadoAtual = GameState.Gameplay;
        SceneManager.LoadScene("Level 2");
    }

    public void IrParaLevel3()
    {
        estadoAtual = GameState.Gameplay;
        SceneManager.LoadScene("Level 3");
    }

    public void IrParaCutsceneFinal()
    {
        estadoAtual = GameState.Final;
        SceneManager.LoadScene("Cutscenefinal");
    }
}
