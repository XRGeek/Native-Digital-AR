using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RenderHeads.Media.AVProVideo;
using System;

public class MediaPlayerEvents : MonoBehaviour {
    public static GameObject loading;
    MediaPlayer mediaPlayer;
    // Use this for initialization

    public GameObject videoRender;
	void Start () {
        mediaPlayer = GetComponent<MediaPlayer>();
        mediaPlayer.Events.AddListener(OnVideoEvent);
    }
	
	
	void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode errorCode) {

        switch (et)
        {
            case MediaPlayerEvent.EventType.ReadyToPlay:
                break;

            case MediaPlayerEvent.EventType.Started:
                Invoke(nameof(TurnOnVideo), 3f);
                break;

            case MediaPlayerEvent.EventType.FinishedPlaying:
                break;
        }
 
    }

    void TurnOnVideo()
    {
        videoRender.SetActive(true);
    }

   
}


