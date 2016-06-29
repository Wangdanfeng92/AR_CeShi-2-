using UnityEngine;
using System.Collections;

/// <summary>
/// 图片循环
/// </summary>
public class ImageLoop : MonoBehaviour {
    [SerializeField]
    private GameObject[] imageObjs;
    [SerializeField]
    private float stayTime = 5;
    [SerializeField]
    private float moveTime = 1;
    [SerializeField]
    private float cellWidth = 410;
    private int index = 0;
    private float tempTime;

	void Start () {
        tempTime = stayTime;
	}
    void Update()
    {
        stayTime -= Time.deltaTime;
        if (stayTime < 0)
        {
            stayTime = tempTime;
            Move();
        }
    }
    /// <summary>移动</summary>
    private void Move()
    {
        if (index == 0)
        {
            imageObjs[imageObjs.Length - 1].transform.localPosition = new Vector3(cellWidth, 0, 0);
        }
        else
        {
            imageObjs[index - 1].transform.localPosition = new Vector3(cellWidth, 0, 0);
        }
        TweenPosition.Begin(imageObjs[index], moveTime, new Vector3(-cellWidth, 0, 0));
        if (index > imageObjs.Length - 2)
        {
            TweenPosition.Begin(imageObjs[0], moveTime, new Vector3(0, 0, 0));
        }
        else
        {
            TweenPosition.Begin(imageObjs[index + 1], moveTime, new Vector3(0, 0, 0));
        }
        index++;
        if (index > imageObjs.Length - 1)
        {
            index = 0;
        }
    }
}
