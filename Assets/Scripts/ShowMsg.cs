using UnityEngine;
using System.Collections;

/// <summary>
/// 显示或隐藏UIRoot
/// </summary>
public class ShowMsg : MonoBehaviour {

    public GameObject UIRoot;

    public void UnUIRoot() 
    {
        UIRoot.SetActive(false);
    }

    /// <summary>
    /// 全屏播放视频
    /// </summary>
    public void PlayMovieFullScreen() 
    {
        Handheld.PlayFullScreenMovie("iu-23.ogv", Color.black, FullScreenMovieControlMode.Full);
    }

}
