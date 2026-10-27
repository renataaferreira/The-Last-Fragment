

using UnityEngine;

public class MiniBossMovimento : MonoBehaviour
{
    public float velocidade = 2f;

    void Update()
    {
        // Move o mini boss continuamente para a direita
        transform.position += Vector3.left * velocidade * Time.deltaTime;
    }
}

