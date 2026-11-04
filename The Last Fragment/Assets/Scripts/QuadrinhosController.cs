using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuadrinhosController : MonoBehaviour
{
    public Image quadrinho1;
    public Image quadrinho2;
    public Image quadrinho3;
    public Image quadrinho4;

    public float tempoNaTela = 3f;
    public float velocidade = 1000f;

    private void Start()
    {
        StartCoroutine(PassarQuadrinhos());
    }

    IEnumerator PassarQuadrinhos()
    {
        // Quadrinho 1 começa aparecendo
        quadrinho1.gameObject.SetActive(true);
        quadrinho2.gameObject.SetActive(false);
        quadrinho3.gameObject.SetActive(false);
        quadrinho4.gameObject.SetActive(false);

        // Fica alguns segundos
        yield return new WaitForSeconds(tempoNaTela);

        // Troca para o quadrinho 2
        quadrinho1.gameObject.SetActive(false);
        quadrinho2.gameObject.SetActive(true);

        // Fica alguns segundos
        yield return new WaitForSeconds(tempoNaTela);

        // Troca para o quadrinho 3
        quadrinho2.gameObject.SetActive(false);
        quadrinho3.gameObject.SetActive(true);

        // Fica alguns segundos
        yield return new WaitForSeconds(tempoNaTela);

        // Troca para o quadrinho 4
        quadrinho3.gameObject.SetActive(false);
        quadrinho4.gameObject.SetActive(true);

        // Fica alguns segundos
        yield return new WaitForSeconds(tempoNaTela);

        // Depois da cutscene, vai para o Level 1
        GameManager.Instance.IrParaLevel1();
    }
}