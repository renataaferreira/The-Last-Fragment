using UnityEngine;

public class Botao : MonoBehaviour
{
    public PortaMovel porta;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            porta.AtivarPorta();
        }
    }
}