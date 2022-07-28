using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayertoDroneSwitch : MonoBehaviour
{
    public GameObject Humanoid;
    public GameObject Drone;
    private PlayableDirector director;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    void Awake()
    {
        director = GetComponent<PlayableDirector>();
        // director.played += Director_Played;
        // director.stopped += Director_Stopped;
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        // controlPanel.SetActive(true);
    }

    private void Director_Played(PlayableDirector obj)
    {
        // controlPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F) && Humanoid.activeSelf == true)
        {
            Drone.SetActive(true);
            director.Play();
            Humanoid.SetActive(false);
        }
        else if(Drone.activeSelf == true && Input.GetKey(KeyCode.F))
        {
            Drone.SetActive(false);
            Humanoid.SetActive(true);
        }
        else
        {
            director.Stop();
        }
    }
}
