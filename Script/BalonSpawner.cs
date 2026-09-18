using UnityEngine;

public class BalonSpawner : MonoBehaviour
{
    public GameObject balonPrefab;
    public float spawnInterval = 4f;  // jeda spawn (detik)
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBalon();
            timer = 0f;
        }
    }

    void SpawnBalon()
    {
        if (balonPrefab == null) return;

        // Spawn di kanan layar, Y acak
        Vector3 spawnPos = new Vector3(10f, Random.Range(-1f, 3f), 0f);

        GameObject balon = Instantiate(balonPrefab, spawnPos, Quaternion.identity);

        // Tambahkan script MoveLeft supaya balon jalan ke kiri
        balon.AddComponent<MoveLeft>();
        balon.GetComponent<MoveLeft>().speed = 3f;
    }
}
