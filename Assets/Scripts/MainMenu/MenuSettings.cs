using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public float MusicParameter;
    public float SoundParameter;
    public float SensitivityParameter;

    public Scrollbar _musicSlider;
    public Scrollbar _soundSlider;
    public Scrollbar _sensitivitySlider;

    private void Start()
    {
        MusicParameter = PlayerPrefs.GetFloat("Music", 1);
        SoundParameter = PlayerPrefs.GetFloat("Sound", 1);
        SensitivityParameter = PlayerPrefs.GetFloat("Sensitivity", 1);
    }

    public void Music()
    {
        MusicParameter = 2 * _musicSlider.value;
        PlayerPrefs.SetFloat("Music", MusicParameter);
    }

    public void Sound()
    {
        SoundParameter = 2 * _soundSlider.value;
        PlayerPrefs.SetFloat("Sound", SoundParameter);
    }

    public void Sensitivity()
    {
        SensitivityParameter = 2 * _sensitivitySlider.value;
        PlayerPrefs.SetFloat("Sensitivity", SensitivityParameter);
    }
}
