using UnityEngine;
using System.Collections;

/// <summary>
/// 导航页
/// </summary>
public class NavegationPage : MonoBehaviour {

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

    public GameObject uiMovePanel,uiStartPanel;

    public UISprite logo, btnStart;
    public UILabel lblAgain;

    void Start()
    {
        PlayerPrefs.SetInt("times", 1);
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
        MoveTopDown();
    }

    private void MoveTopDown() 
    {
        if (uiStartPanel.activeInHierarchy == true)
        {
            logo.GetComponent<TweenPosition>().enabled = true;
            btnStart.GetComponent<TweenPosition>().enabled = true;
            lblAgain.GetComponent<TweenPosition>().enabled = true;
        }
    }

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
            uiMovePanel.SetActive(false);
            uiStartPanel.SetActive(true);
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
