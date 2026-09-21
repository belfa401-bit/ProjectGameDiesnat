using UnityEngine;
using UnityEngine.Video;

public class VideoSpeedController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Transform player;       // referensi ke Bombi
    public float baseSpeed = 1.3f;   // kecepatan awal
    public float speedStep = 1f; // tambahan speed tiap milestone
    public float distanceStep = 20f; // tiap 100 meter naik speed

    private float lastStepDistance = 0f;

    void Start()
    {
        videoPlayer.playbackSpeed = baseSpeed;
    }

    void Update()
    {
        float distance = player.position.x;

        // kalau sudah melewati milestone baru
        if (distance >= lastStepDistance + distanceStep)
        {
            videoPlayer.playbackSpeed += speedStep;
            lastStepDistance += distanceStep;

            Debug.Log("Playback speed sekarang: " + videoPlayer.playbackSpeed);
        }
    }
}
