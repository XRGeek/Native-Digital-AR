using System.Collections;
using System.Collections.Generic;
using RenderHeads.Media.AVProVideo;
using UnityEngine;

public class LocalVideoControl : MonoBehaviour
{
   public MediaPlayer mediaPlayer;

    public void LoadVideo(string url)
    {
        mediaPlayer.OpenMedia(new MediaPath(url, MediaPathType.AbsolutePathOrURL));
    }
}
