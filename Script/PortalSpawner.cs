// PortalSpawner.cs
using UnityEngine;
using System.Collections;

public class PortalSpawner : MonoBehaviour
{
    public GameObject portalPrefab;   // prefab di Project
    public Transform player;          // drag Player ke sini
    public float groundY = 0f;        // posisi Y portal di tanah

    [Header("Scene references")]
    public GameObject instructionPanel; // drag InstructionPanel dari Hierarchy ke sini

    private float nextSpawnTime = 30f;   // spawn pertama di detik ke-30
    private float spawnInterval = 30f;   // tiap 30 detik

    // spawn offset dan delay collider bisa diatur dari Inspector jika perlu
    [Header("Spawn tuning")]
    public float spawnOffsetX = 16f;     // jarak ke kanan dari player saat spawn
    public float colliderEnableDelay = 0.25f; // delay sebelum collider aktif

    void Update()
    {
        if (DistanceManager.instance == null) return;

        float time = DistanceManager.instance.GetTime();

        if (time >= nextSpawnTime)
        {
            SpawnPortal();
            nextSpawnTime += spawnInterval; // target spawn berikutnya
        }
    }

    void SpawnPortal()
    {
        if (portalPrefab == null || player == null) return;

        Vector3 spawnPos = new Vector3(player.position.x + spawnOffsetX, groundY, 0f);
        GameObject portal = Instantiate(portalPrefab, spawnPos, Quaternion.identity);

        // assign InstructionPanel ke instance portal agar clone punya referensi scene
        PortalTrigger pt = portal.GetComponent<PortalTrigger>();
        if (pt != null && instructionPanel != null)
        {
            pt.instructionPanel = instructionPanel;
        }

        // disable collider sementara lalu aktifkan setelah delay untuk menghindari overlap spawn
        Collider2D col = portal.GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
            StartCoroutine(EnableColliderAfterDelay(col, colliderEnableDelay));
        }
    }

    IEnumerator EnableColliderAfterDelay(Collider2D col, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (col != null) col.enabled = true;
    }
}
