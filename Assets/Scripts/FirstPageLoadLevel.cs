using UnityEngine;
using System.Collections;

/// <summary>
/// 第一次加载显示导航页，之后就不在显示
/// </summary>
public class FirstPageLoadLevel : MonoBehaviour {

	void Start() {
        if (PlayerPrefs.GetInt("times") == 1)
        {
            Invoke("loadMains", 3f);
        }
        else
        {
            Invoke("loadLevels", 3f);
        }
	}

    void loadMains()
    {
        Application.LoadLevelAsync(1);
    }

    void loadLevels()
    {
        Application.LoadLevelAsync(3);
    }

}
