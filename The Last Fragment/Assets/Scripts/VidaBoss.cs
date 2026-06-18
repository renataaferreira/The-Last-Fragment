using UnityEngine;

public class VidaBoss : MonoBehaviour
{
    public int vidaMaxima = 30;
    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Função pública para a bala poder ativar
    public void TomarDanoBoss(int quantidadeDano)
    {
        vidaAtual -= quantidadeDano;
        Debug.Log("Vida do Boss atual: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("O Boss morreu!");
        Destroy(gameObject); // Remove o Boss da cena
    }
}