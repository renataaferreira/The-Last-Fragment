
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject guiPersistente;
    private bool carregandoGUI = false;

    // Contador de moedas
    private int quantidadeMoedas = 0;
    private TMP_Text textoMoedas;

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

                    StartCoroutine(LocalizarTextoMoedas());

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
            textoMoedas = null;
        }
    }

    // Localiza o texto de moedas na GUI
    private IEnumerator LocalizarTextoMoedas()
    {
        yield return null;

        TMP_Text[] textos = FindObjectsByType<TMP_Text>(
            FindObjectsSortMode.None
        );

        textoMoedas = null;

        foreach (TMP_Text texto in textos)
        {
            if (texto.gameObject.name == "TextoMoedas")
            {
                textoMoedas = texto;
                break;
            }
        }

        AtualizarTextoMoedas();
    }

    // Adiciona moedas ao contador
    public void AdicionarMoedas(int quantidade)
    {
        quantidadeMoedas += quantidade;

        AtualizarTextoMoedas();

        Debug.Log("Moedas coletadas: " + quantidadeMoedas);
    }

    // Atualiza o texto da GUI
    private void AtualizarTextoMoedas()
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = "Moedas: " + quantidadeMoedas;
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