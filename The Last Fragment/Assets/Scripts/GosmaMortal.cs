using UnityEngine;

public class GosmaMortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            VidaPlayer vida = collision.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                vida.Morrer();
            }
        }
    }
}