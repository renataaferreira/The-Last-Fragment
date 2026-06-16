using UnityEngine;

public class Dano : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER FUNCIONOU!");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("PLAYER ENCONTROU O BOSS!");

            VidaPlayer vida = collision.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                Debug.Log("DANO APLICADO!");
                vida.TomarDano(10);
            }
        }
    }
}