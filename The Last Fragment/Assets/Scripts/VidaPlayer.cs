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

        if (barraVida != null)
        {
            barraVida.maxValue = vidaMaxima;
            barraVida.value = vidaAtual;
        }
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        if (barraVida != null)
        {
            barraVida.value = vidaAtual;
        }

        if (vidaAtual <= 0)
        {
            transform.position = Vector3.zero;

            vidaAtual = vidaMaxima;

            if (barraVida != null)
            {
                barraVida.value = vidaAtual;
            }
        }
    }
}