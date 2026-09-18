using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 3f;
    public Transform spawnPoint;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
