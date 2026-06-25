using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public Slider barraVida;

    public int vidaMaxima = 100;
    private int vidaAtual;

    private Transform checkpointAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;

        if (barraVida == null)
        {
            Debug.LogError("A Barra Vida não foi atribuída no Inspector!");
            return;
        }

        barraVida.maxValue = vidaMaxima;
        barraVida.value = vidaAtual;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        barraVida.value = vidaAtual;

        Debug.Log("Vida: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    public void RecuperarVida(int quantidade)
    {
        vidaAtual += quantidade;

        if (vidaAtual > vidaMaxima)
        {
            vidaAtual = vidaMaxima;
        }

        barraVida.value = vidaAtual;

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
        barraVida.value = vidaAtual;
    }
}