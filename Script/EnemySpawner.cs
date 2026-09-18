using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float groundY = 0f;

    private float nextSpawnTime = 5f;   // spawn pertama di detik ke-5
    private float spawnInterval = 5f;   // jeda antar spawn (detik)
    private float minInterval = 2f;     // mentok 2 detik

    void Update()
    {
        if (DistanceManager.instance == null) return;

        float time = DistanceManager.instance.GetTime(); // ambil waktu dari DistanceManager

        if (time >= nextSpawnTime)
        {
            SpawnEnemy();

            // Kurangi interval seiring waktu (contoh: tiap 30 detik)
            if (time >= 30f)
            {
                spawnInterval = Mathf.Max(minInterval, spawnInterval - 1f);
            }

            // Set target spawn berikutnya
            nextSpawnTime = time + spawnInterval;
            Debug.Log("Next spawn at: " + nextSpawnTime + " (interval: " + spawnInterval + ")");
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[randomIndex];

        Vector3 spawnPos = new Vector3(player.position.x + 20f, groundY, 0f);
        Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        Debug.Log("Spawned enemy at " + spawnPos);
    }
}
