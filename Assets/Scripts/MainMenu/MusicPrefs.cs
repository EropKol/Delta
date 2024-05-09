using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPrefs : MonoBehaviour
{
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();

        PrefsChange();
    }

    public void PrefsChange()
    {
        _audio.volume = PlayerPrefs.GetFloat("Music", 0.5f);
    }
}
