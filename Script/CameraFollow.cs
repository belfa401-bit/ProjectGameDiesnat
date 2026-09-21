using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = new Vector3(
            player.position.x + offset.x,
            offset.y,   // Y dikunci
            offset.z    // Z tetap -10 untuk 2D
        );

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}