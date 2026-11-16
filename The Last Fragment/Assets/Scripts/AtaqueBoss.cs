using UnityEngine;

public class AtaqueBoss : MonoBehaviour
{
    public int dano = 10;
    public GameObject espinhoPrefab;
    public Transform spawnPoint;

    public float attackCooldown = 3f;
    public float angle = 30f;
    void Start()
    {
        InvokeRepeating(nameof(Attack), 1f, attackCooldown);
    }

    void Attack()
    {
        // Espinho para a direita
        SpawnSpike(0);

        // Espinho para a esquerda
        SpawnSpike(180);

        // Espinho para a direita, subindo 30 graus
        SpawnSpike(angle);

        // Espinho para a esquerda, subindo 30 graus
        SpawnSpike(180 - angle);
    }

    void SpawnSpike(float angle)
    {
        GameObject spike = Instantiate(
            espinhoPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        Espinho projectile = spike.GetComponent<Espinho>();

        float radians = angle * Mathf.Deg2Rad;

        projectile.direction = new Vector2(
            Mathf.Cos(radians),
            Mathf.Sin(radians)
        );
    }


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