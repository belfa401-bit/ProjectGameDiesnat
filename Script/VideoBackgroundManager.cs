using UnityEngine;
using UnityEngine.Video;

public class VideoBackgroundManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip fullCycleClip; // video berisi siang-sore-malam

    void Start()
    {
        videoPlayer.clip = fullCycleClip;
        videoPlayer.isLooping = true; // otomatis loop
        videoPlayer.Play();
    }
}
