using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public float velocidade = 2f;
    public float altura = 3f;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float movimento = Mathf.Sin(Time.time * velocidade) * altura;

        transform.position = posicaoInicial + Vector3.up * movimento;
    }
}