using UnityEngine;
using TMPro;

public class ContadorFragmentos : MonoBehaviour
{
    public static ContadorFragmentos Instancia;

    [SerializeField] private TextMeshProUGUI textoFragmentos;

    private int fragmentosColetados = 0;
    private int totalFragmentos = 3;

    private void Awake()
    {
        Instancia = this;
        AtualizarTexto();
    }

    public void ColetarFragmento()
    {
        fragmentosColetados++;
        AtualizarTexto();

        Debug.Log("Fragmentos coletados: " + fragmentosColetados);
    }

    private void AtualizarTexto()
    {
        textoFragmentos.text = "FRAGMENTOS: " +
                               fragmentosColetados +
                               "/" +
                               totalFragmentos;
    }
}