using UnityEngine;
using System.Collections;
using UnityEditor;
public class DBALL : Editor
{

    [MenuItem("BuildBundle/Create AssetBunldes ALL")]
    static void CreateAssetBunldesALL()
    {
        Caching.CleanCache();

        string Path = Application.dataPath + "/StreamingAssets/ALLforAndroid.assetbundle";

        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        foreach (Object obj in SelectedAsset)
        {
            Debug.Log("Create AssetBunldes name :" + obj);
        }

        //这里注意第二个参数就行    
        //里面第一个参数 是 打包单个物体   第二个参数要打包的对象组成的数组，第三个参数是打包保存路径，第四个是打包方式，第五个是打包平台

        if (BuildPipeline.BuildAssetBundle(null, SelectedAsset, Path,BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android))
            AssetDatabase.Refresh();
    }
}
