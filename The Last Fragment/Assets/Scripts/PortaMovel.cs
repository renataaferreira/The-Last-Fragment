using UnityEngine;

public class PortaMovel : MonoBehaviour
{
    public float altura = 5f;
    public float velocidade = 2f;

    private Vector3 posicaoInicial;
    private Vector3 posicaoFinal;

    private bool ativada = false;

    void Start()
    {
        posicaoInicial = transform.position;
        posicaoFinal = posicaoInicial + Vector3.up * altura;
    }

    void Update()
    {
        if (ativada)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoFinal,
                velocidade * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                posicaoInicial,
                velocidade * Time.deltaTime
            );
        }
    }

    public void AtivarPorta()
    {
        ativada = !ativada;
    }
}