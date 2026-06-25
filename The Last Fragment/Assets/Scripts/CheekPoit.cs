using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool ativado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !ativado)
        {
            VidaPlayer vida = collision.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                vida.DefinirCheckpoint(transform);
                ativado = true;

                Debug.Log("Checkpoint ativado!");
            }
        }
    }
}