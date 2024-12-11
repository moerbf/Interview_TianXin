using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoUI : UIBase
{
    public override UILayer uIlayer => UILayer.Background;

    public RawImage videoRawImage;
    public VideoManager videoManager;
    public override void Awake()
    {
        base.Awake();
        videoRawImage = transform.Find("VideoRawImage").GetComponent<RawImage>();
        videoManager = transform.Find("VideoPlayer").GetComponent<VideoManager>();

        // 默认不可交互 
        defaultBlocksRaycasts = false;
    }
    public void Start()
    {
        if (videoRawImage != null && videoManager != null)
        {
            videoRawImage.texture = videoManager.videoPlayer?.targetTexture;
        }
        else
        {
            Debug.LogError("VideoRawImage or VideoManager is null");
        }
    }
    public override void OnEnter()
    {
        base.OnEnter();
        videoManager.RandomPlay();
    }
    public override void OnPause()
    {
        base.OnPause();
        videoManager.Pause();
    }
    public override void OnResume()
    {
        base.OnResume();
        videoManager.Resume();
    }
    public void RandomPlay()
    {
        videoManager.RandomPlay();
    }
}
