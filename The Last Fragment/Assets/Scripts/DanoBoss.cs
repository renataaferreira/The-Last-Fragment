using UnityEngine;

public class Dano : MonoBehaviour
{
    public int dano = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VidaPlayer vida = collision.gameObject.GetComponent<VidaPlayer>();

            if (vida != null)
            {
                vida.TomarDano(dano);
                Debug.Log("Dano aplicado!");
            }
        }
    }
}