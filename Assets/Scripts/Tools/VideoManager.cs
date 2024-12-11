using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.targetTexture = Resources.Load<RenderTexture>("RenderTextures/Video_RT"); // 设置输出纹理路径
        videoPlayer.isLooping = true;

        videoClips = Resources.LoadAll<VideoClip>("Videos"); // 读取所有视频剪辑
    }
    public void Pause()
    {
        videoPlayer.Pause();
    }
    public void Play(int index)
    {
        videoPlayer.clip = videoClips[index];
        videoPlayer.Play();
    }
    public void RandomPlay()
    {
        int randomIndex = Random.Range(0, videoClips.Length);
        videoPlayer.clip = videoClips[randomIndex];
        videoPlayer.Play();
    }
    public void Resume()
    {
        videoPlayer.Play();
    }
}
