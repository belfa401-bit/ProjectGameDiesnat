using UnityEngine;
using UnityEngine.Video;

public class VideoBackgroundManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip dayClip;
    public VideoClip eveningClip;
    public VideoClip nightClip;

    public Transform player;
    public float eveningDistance = 500f;
    public float nightDistance = 1000f;

    void Update()
    {
        float distance = player.position.x;

        if (distance >= nightDistance && videoPlayer.clip != nightClip)
        {
            ChangeBackground(nightClip);
        }
        else if (distance >= eveningDistance && videoPlayer.clip != eveningClip)
        {
            ChangeBackground(eveningClip);
        }
    }

    void ChangeBackground(VideoClip newClip)
    {
        videoPlayer.clip = newClip;
        videoPlayer.Play();
    }
}
