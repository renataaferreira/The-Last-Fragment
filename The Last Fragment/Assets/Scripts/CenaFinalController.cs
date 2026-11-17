using UnityEngine;
using System.Collections;

public class CenaFinalController : MonoBehaviour
{
    public GameObject quadrinhoVitoria;
    public GameObject quadrinhoFinal;
    public GameObject textoAgradecimento;
    public GameObject creditos;

    public float tempoNaTela = 4f;

    void Start()
    {
        StartCoroutine(PassarCenaFinal());
    }

    IEnumerator PassarCenaFinal()
    {
        quadrinhoVitoria.SetActive(true);
        quadrinhoFinal.SetActive(false);
        textoAgradecimento.SetActive(false);
        creditos.SetActive(false);

        yield return new WaitForSeconds(tempoNaTela);

        quadrinhoVitoria.SetActive(false);
        quadrinhoFinal.SetActive(true);
        textoAgradecimento.SetActive(true);
        creditos.SetActive(true);
    }
}