using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float velocidade = 5f;
    [SerializeField] float offSetX, offSetY;

    private Transform pTransform => player.GetComponent<Transform>();
    private SpriteRenderer pSR => player.GetComponent<SpriteRenderer>();


    void LateUpdate()
    {
        if(!pSR.flipX)
        {
            offSetX = Math.Abs(offSetX);
            //offSetY = Math.Abs(offSetY);
        }
        else
        {
            offSetX = Math.Abs(offSetX) * -1;
            //offSetY = Math.Abs(offSetY) * -1;
        }

        if (player != null)
        {
            Vector3 posicaoDesejada = new Vector3(pTransform.position.x + offSetX, pTransform.position.y + offSetY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidade * Time.deltaTime);
        }
    }
}