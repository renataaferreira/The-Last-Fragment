using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool ativado = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !ativado)
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.SetCheckpoint(transform);
                ativado = true;

                Debug.Log("Checkpoint ativado!");
            }
        }
    }
}