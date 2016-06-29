using UnityEngine;
using System.Collections;

/// <summary>
/// ≤•∑≈ ”∆µ
/// </summary>
[RequireComponent(typeof(MMT.MobileMovieTexture))]
public class TestMobileTexture : MonoBehaviour 
{
    private MMT.MobileMovieTexture m_movieTexture;
    public GameObject UIroot,PlaneMovie,spPlay,btnBack;
    public AudioSource music;

    void Awake()
    {
        m_movieTexture = GetComponent<MMT.MobileMovieTexture>();

        m_movieTexture.onFinished += OnFinished;

        spPlay.SetActive(false);
    }

    void OnFinished(MMT.MobileMovieTexture sender)
    {
        Debug.Log(sender.Path + " has finished ");
    }

    public Camera cameraUI;

    void Update() 
    {
        MovieController();
        ShowOrNoMoviePlane();
    }

    private void ShowOrNoMoviePlane()
    {
        if (UIroot.activeInHierarchy)
        {
            PlaneMovie.SetActive(true);
            btnBack.SetActive(false);
        }
        else
        {
            m_movieTexture.Stop();
            btnBack.SetActive(true);
            PlaneMovie.SetActive(false);
        }
    }

    private void MovieController() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraUI.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "movies")
                {
                    if (m_movieTexture.IsPlaying)
                    {
                        m_movieTexture.Pause = true;
                        music.Pause();
                        spPlay.SetActive(true);
                    }
                    else
                    {
                      
                        if (!m_movieTexture.Pause)
                        {
                            m_movieTexture.Play();
                            music.Play();
                        }
                        else
                        {
                            m_movieTexture.Pause = false;
                            music.Play();
                            spPlay.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    /**
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0.0f, 0.0f, Screen.width, Screen.height));

        var currentPosition = (float)m_movieTexture.PlayPosition;
		
		var newPosition = GUILayout.HorizontalSlider(currentPosition,0.0f,(float)m_movieTexture.Duration);

        if (newPosition != currentPosition)
        {
			m_movieTexture.PlayPosition = newPosition;
        }
        
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(m_movieTexture.IsPlaying ? "Pause" : "Play"))
        {
            if (m_movieTexture.IsPlaying)
            {
                m_movieTexture.Pause = true;
            }
            else
            {
                if (!m_movieTexture.Pause)
                {
                    m_movieTexture.Play();
                }
                else
                {
                    m_movieTexture.Pause = false;
                }
            }
        }

        //if (GUILayout.Button("Stop"))
        //{
        //    m_movieTexture.Stop();
        //}

        GUILayout.EndHorizontal();

        GUILayout.EndArea();

     }
     * */
}
