using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private Transform target; // Referencia o player

    [Header("Configurações")]
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f); //Distancia a camera do alvo

    void LateUpdate() //Roda depois de todos os Updates, garantindo que o player se mova antes da camera
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); //Interpolação linear para suavizar o movimento da câmera

        transform.position = smoothedPosition;
    }
}