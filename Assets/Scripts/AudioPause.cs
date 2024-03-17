using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPause : MonoBehaviour
{
    bool playing = true;
    void Update()
    {
        if(Time.timeScale == 0 && playing)
        {
            this.gameObject.GetComponent<AudioSource>().Pause();
            playing = false;
        }
        if (Time.timeScale == 1 && !playing)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            playing = true;
        }
    }
}
