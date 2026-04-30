using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float velocidade = 5f;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 posicaoDesejada = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidade * Time.deltaTime);
        }
    }
}