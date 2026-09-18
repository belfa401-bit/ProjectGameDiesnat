using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        // Ambil posisi background sekarang
        Vector3 pos = transform.position;

        // Ikuti player di sumbu X saja
        pos.x = player.position.x;

        // Y tetap (nggak ikut player)
        // Jadi background nggak loncat ke atas/bawah
        // pos.y dibiarkan apa adanya

        transform.position = pos;
    }
}
