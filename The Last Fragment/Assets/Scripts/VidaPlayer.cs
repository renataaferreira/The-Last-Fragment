using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMaxima = 100;
    private int vidaAtual;

    private Slider barraVida;
    private Transform checkpointAtual;

    private void Awake()
    {
        vidaAtual = vidaMaxima;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    private void Start()
    {
        StartCoroutine(EncontrarBarraAposCarregar());
    }

    private void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        StartCoroutine(EncontrarBarraAposCarregar());
    }

    private IEnumerator EncontrarBarraAposCarregar()
    {
        // Aguarda a cena terminar de carregar.
        yield return null;

        EncontrarBarraVida();
        AtualizarBarraVida();
    }

    private void EncontrarBarraVida()
    {
        Slider[] sliders = FindObjectsByType<Slider>(
            FindObjectsSortMode.None
        );

        barraVida = null;

        foreach (Slider slider in sliders)
        {
            if (slider.gameObject.name == "BarraDeVida")
            {
                barraVida = slider;
                break;
            }
        }

        if (barraVida == null)
        {
            Debug.LogWarning("BarraDeVida não encontrada na GUI.");
        }
    }

    private void AtualizarBarraVida()
    {
        if (barraVida == null)
        {
            return;
        }

        barraVida.maxValue = vidaMaxima;
        barraVida.value = vidaAtual;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);

        AtualizarBarraVida();

        Debug.Log("Vida: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    public void RecuperarVida(int quantidade)
    {
        vidaAtual += quantidade;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);

        AtualizarBarraVida();

        Debug.Log("Vida recuperada! Vida atual: " + vidaAtual);
    }

    public void DefinirCheckpoint(Transform novoCheckpoint)
    {
        checkpointAtual = novoCheckpoint;
    }

    public void Morrer()
    {
        Debug.Log("Morreu!");

        if (checkpointAtual != null)
        {
            transform.position = checkpointAtual.position;
        }
        else
        {
            transform.position = Vector3.zero;
        }

        vidaAtual = vidaMaxima;

        AtualizarBarraVida();
    }
}