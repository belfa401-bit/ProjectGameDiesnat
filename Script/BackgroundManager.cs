using UnityEngine;
using UnityEngine.Video;

public class BackgroundManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip dayClip;
    public VideoClip eveningClip;
    public VideoClip nightClip;

    public float cycleDuration = 60f; // total siklus 60 detik
    private float timer = 0f;

    void Update()
    {
        if (DistanceManager.instance.isGameOver) return;

        timer += Time.deltaTime;
        float cycleTime = timer % cycleDuration; // looping siklus

        if (cycleTime < 20f && videoPlayer.clip != dayClip)
            ChangeBackground(dayClip);
        else if (cycleTime < 40f && videoPlayer.clip != eveningClip)
            ChangeBackground(eveningClip);
        else if (cycleTime < 60f && videoPlayer.clip != nightClip)
            ChangeBackground(nightClip);
    }

    void ChangeBackground(VideoClip newClip)
    {
        videoPlayer.clip = newClip;
        videoPlayer.Play();
    }
}
