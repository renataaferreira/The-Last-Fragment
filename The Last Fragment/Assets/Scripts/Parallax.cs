using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraTransform;
    public float fatorParallax = 0.2f;

    private Vector3 ultimaPosicaoCamera;

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        ultimaPosicaoCamera = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 movimento =
            cameraTransform.position - ultimaPosicaoCamera;

        transform.position += new Vector3(
            movimento.x * fatorParallax,
            movimento.y * fatorParallax,
            0f
        );

        ultimaPosicaoCamera = cameraTransform.position;
    }
}
