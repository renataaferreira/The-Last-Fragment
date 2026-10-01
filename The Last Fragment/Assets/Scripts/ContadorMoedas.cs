
using UnityEngine;
using TMPro;

public class ContadorMoedas : MonoBehaviour
{
    public static ContadorMoedas Instancia;

    public TMP_Text textoMoedas;
    private int totalMoedas = 0;

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        Instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        AtualizarTexto();
    }

    public void ColetarMoeda()
    {
        totalMoedas++;
        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = "MOEDAS: " + totalMoedas;
        }
    }
}