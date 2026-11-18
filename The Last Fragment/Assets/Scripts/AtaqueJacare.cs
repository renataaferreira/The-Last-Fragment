using UnityEngine;
using System.Collections;

public class AtaqueJacare : MonoBehaviour
{
    [Header("Referências")]
    private Transform player => GameObject.Find("Player").GetComponent<Transform>();
    [SerializeField] private GameObject prefabProjetil;
    [SerializeField] private Transform pontoDisparo;
    private SpriteRenderer sprite => GetComponent<SpriteRenderer>();

    [Header("Configurações")]
    [SerializeField] private float areaDeteccao = 8f;
    [SerializeField] private float intervaloDisparo = 2f;

    private bool podeAtirar = true;

    private void Update()
    {
        float distancia = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distancia <= areaDeteccao && podeAtirar)
        {
            StartCoroutine(Atirar());
        }
    }

    private IEnumerator Atirar()
    {
        podeAtirar = false;

        GameObject projetil = Instantiate(
            prefabProjetil,
            pontoDisparo.position,
            Quaternion.identity
        );

        // Boss naturalmente olha para a esquerda
        Vector2 direcao = sprite.flipX
            ? Vector2.right
            : Vector2.left;

        projetil.GetComponent<ProjetilJacare>().direction = direcao;

        yield return new WaitForSeconds(intervaloDisparo);

        podeAtirar = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(
            transform.position,
            areaDeteccao
        );
    }
}