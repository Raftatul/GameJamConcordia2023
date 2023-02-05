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
            if (AudioSource.clip != Sounds[0])
            {
                StartFade(2, 0);
                Sounds[0].Play(AudioSource);
                StartFade(2, 1);
            }
        }
        else
        {
            if (AudioSource.clip != Sounds[1])
            {
                StartFade(2, 0);
                // play night
                Sounds[1].Play(AudioSource);
                StartFade(2, 1);
            }
        }
    }

    //public void Listener_Night()
    //{
    //    Sounds[1].Play(AudioSource);
    //}

    public void Listener_RainEvent()
    {
        if (AudioSource.clip != Sounds[2])
        {
            StartFade(2, 0);
            Sounds[2].Play(AudioSource);
            StartFade(2, 1);
        }
    }


    public void Listener_WindEvent()
    {
        if (AudioSource.clip != Sounds[3])
        {
            StartFade(2, 0);
            Sounds[3].Play(AudioSource);
            StartFade(2, 1);
        }
    }


    public IEnumerator StartFade(float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = AudioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            AudioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }


}
