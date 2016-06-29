using UnityEngine;
using System.Collections;

public class DiaoYong : MonoBehaviour
{
    private string path = "http://huizhan.xiniu3d.com/y/ALLforAndroid.assetBundle";
    private string assetName = "Book";

    public GameObject[] imageTargets;

    void Start()
    {
        StartCoroutine(LoadAllGameObject());
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //读取全资源
    IEnumerator LoadAllGameObject()
    {
        Debug.Log("...");
        //加载网络
        //WWW www = WWW.LoadFromCacheOrDownload(path, 1);
        //加载本地
        WWW www = new WWW("file://" + Application.streamingAssetsPath + "/ALLforAndroid.assetBundle");
        yield return www;

        if (www.error != null)
            yield return null;
        AssetBundle bundle = www.assetBundle;
        if (assetName == "")
            Instantiate(bundle.mainAsset);
        else
        {
            //for (int i = 0; i < imageTargets.Length; i++)
            //{
            //    GameObject cube = Instantiate(bundle.LoadAsset(assetName + (i + 1))) as GameObject;
            //    cube.transform.parent = imageTargets[i].transform;
            //    cube.transform.position = imageTargets[i].transform.position;
            //    cube.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //}



        }
        www.assetBundle.Unload(false);
    }



}
