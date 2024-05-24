using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPrefs : MonoBehaviour
{
    private AudioSource _audio;

    void Start()
    {
        PrefsChange();
    }

    public void PrefsChange()
    {
        _audio = GetComponent<AudioSource>();

        _audio.volume = PlayerPrefs.GetFloat("Sound", 0.5f);
    }
}
