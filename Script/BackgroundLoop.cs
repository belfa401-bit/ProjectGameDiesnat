using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float length; // panjang sprite background
    public Transform player;

    void Update()
    {
        if (player.position.x > transform.position.x + length)
        {
            transform.position = new Vector3(transform.position.x + length, transform.position.y, transform.position.z);
        }
    }
}
