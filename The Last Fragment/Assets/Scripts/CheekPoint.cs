using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool ativado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ativado)
            return;

        if (collision.CompareTag("Player"))
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