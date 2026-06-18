using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public Slider barraVida;

    public int vidaMaxima = 100;
    private int vidaAtual;

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
            Debug.Log("Morreu!");

            transform.position = Vector3.zero;

            vidaAtual = vidaMaxima;
            barraVida.value = vidaAtual;
        }
    }
}