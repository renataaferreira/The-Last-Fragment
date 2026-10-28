
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject guiPersistente;
    private bool carregandoGUI = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += AoCarregarCena;
    }

    private void Start()
    {
        IrParaMenu();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= AoCarregarCena;
            Instance = null;
        }
    }

    private bool EhFase(string nome)
    {
        return nome == "Level 1"
            || nome == "Level 2"
            || nome == "Level 3";
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        if (cena.name == "GUI")
        {
            carregandoGUI = false;

            GameObject[] objetosRaiz = cena.GetRootGameObjects();

            foreach (GameObject objeto in objetosRaiz)
            {
                Canvas canvas = objeto.GetComponentInChildren<Canvas>(true);

                if (canvas != null)
                {
                    guiPersistente = canvas.transform.root.gameObject;
                    DontDestroyOnLoad(guiPersistente);
                    return;
                }
            }

            Debug.LogError("Nenhum Canvas encontrado na cena GUI!");
            return;
        }

        if (EhFase(cena.name))
        {
            if (guiPersistente == null && !carregandoGUI)
            {
                carregandoGUI = true;
                SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
            }
        }
        else
        {
            if (guiPersistente != null)
            {
                Destroy(guiPersistente);
                guiPersistente = null;
            }

            carregandoGUI = false;
        }
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IrParaConfiguracoes()
    {
        SceneManager.LoadScene("Configuracoes");
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
