using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Player")]
    public Transform player;

    [Header("Smooth Settings")]
    public float smoothSpeed = 0.125f;

    [Header("Offset Kamera")]
    // Atur offset X negatif biar player agak ke kiri
    public Vector3 offset = new Vector3(-3f, 0f, -10f);

    void LateUpdate()
    {
        if (player == null) return;

        // Posisi kamera yang diinginkan
        Vector3 desiredPosition = player.position + offset;

        // Lerp biar gerakan kamera halus
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update posisi kamera
        transform.position = smoothedPosition;
    }
}
