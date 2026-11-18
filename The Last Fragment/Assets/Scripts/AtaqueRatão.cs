using UnityEngine;
using System.Collections;

public class AtaqueRatão : MonoBehaviour
{
    [Header("Ataque")]
    [SerializeField] private Animator anim;
    [SerializeField] private float alcance = 3f;
    [SerializeField] private int dano = 1;
    [SerializeField] private float tempoEspera = 2f;

    [Header("Detecção")]
    private Transform player => GameObject.Find("Player").GetComponent<Transform>();

    public bool isAttacking = false;

    private bool podeAtacar = true;

    private void Update()
    {
        if (player == null || !podeAtacar || isAttacking)
            return;

        float distancia = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distancia <= alcance)
        {
            IniciarAtaque();
        }
    }

    private void IniciarAtaque()
    {
        isAttacking = true;
        podeAtacar = false;

        anim.SetBool("isWalking", false);
    }

    // Chamado pelo Animation Event no momento do impacto
    public void CausarDano()
    {
        Collider2D[] atingidos = Physics2D.OverlapCircleAll(
            transform.position,
            alcance
        );

        foreach (Collider2D outro in atingidos)
        {
            if (outro.CompareTag("Player"))
            {
                VidaPlayer vida = outro.GetComponentInParent<VidaPlayer>();

                if (vida != null)
                    vida.TomarDano(dano);
            }
        }
    }

    // Chamado por outro Animation Event no final da animação
    public void FinalizarAtaque()
    {
        isAttacking = false;
        anim.SetBool("isWalking", true);
        StartCoroutine(TempoDeEspera());
    }

    private IEnumerator TempoDeEspera()
    {
        yield return new WaitForSeconds(tempoEspera);

        podeAtacar = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alcance);
    }
}