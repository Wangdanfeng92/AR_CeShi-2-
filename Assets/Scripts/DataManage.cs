using UnityEngine;
using System.Collections;

/// <summary>
/// 获取图片和视频（视频未添加）
/// </summary>
public class DataManage : MonoBehaviour {

    public GameObject txture;
    private TrackableEventHandler handler;

    void Update() 
    {
        if (txture!=null)
        {
            txture.GetComponent<UITexture>().mainTexture = handler.texture2D;
        }
    }

}
