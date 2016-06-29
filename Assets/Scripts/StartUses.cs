using UnityEngine;
using System.Collections;

/// <summary>
/// 加载场景
/// </summary>
public class StartUses : MonoBehaviour {

    public void LoadMain() 
    {
        Application.LoadLevelAsync(2);
    }

    public void LoadNavegationPage() 
    {
        Application.LoadLevelAsync(3);
    }

    public void LoadStartUsePage() 
    {
        Application.LoadLevelAsync(1);
    }

    public void LoadSettingPage() 
    {
        Application.LoadLevelAsync(4);
    }

}
