using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGS_Manager : MonoBehaviour
{
    public AudioSource AudioSource;
    public List<SO_Audio_Simple> Sounds;


    public void Listener_SunnyDayEvent()
    {

        if (GlobalVariable.day)
        {
            Sounds[0].Play(AudioSource);
        }
        else
        {
            // play night
            Sounds[1].Play(AudioSource);
        }
    }

    //public void Listener_Night()
    //{
    //    Sounds[1].Play(AudioSource);
    //}

    public void Listener_RainEvent()
    {
        Sounds[2].Play(AudioSource);
    }


    public void Listener_WindEvent()
    {
        Sounds[3].Play(AudioSource);
    }
}
