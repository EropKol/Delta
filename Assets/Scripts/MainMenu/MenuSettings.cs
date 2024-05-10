using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public float MusicParameter;
    public float SoundParameter;
    public float SensitivityParameter;
    public float FOVParameter;

    public Scrollbar _musicSlider;
    public Scrollbar _soundSlider;
    public Scrollbar _sensitivitySlider;
    public Scrollbar _fieldOfViewSlider;

    private MusicPrefs _music;
    private List<SoundPrefs> _sound = new List<SoundPrefs>();
    private CameraFOVScript _camera;

    private void Start()
    {
        _music = FindObjectOfType<MusicPrefs>().GetComponent<MusicPrefs>();

        _camera = FindObjectOfType<CameraFOVScript>().GetComponent<CameraFOVScript>();

        MusicParameter = PlayerPrefs.GetFloat("Music", 1);
        _musicSlider.value = MusicParameter;
        SoundParameter = PlayerPrefs.GetFloat("Sound", 1);
        _soundSlider.value = SoundParameter;
        SensitivityParameter = PlayerPrefs.GetFloat("Sensitivity", 1);
        _sensitivitySlider.value = SensitivityParameter;
        FOVParameter = PlayerPrefs.GetFloat("FOV", 90);
        _fieldOfViewSlider.value = FOVParameter / 180;
    }

    public void Music()
    {
        MusicParameter = _musicSlider.value;
        PlayerPrefs.SetFloat("Music", MusicParameter);

        if (_music != null)
        {
            _music.PrefsChange();
        }
    }

    public void Sound()
    {
        SoundParameter = _soundSlider.value;
        PlayerPrefs.SetFloat("Sound", SoundParameter);

        _sound.AddRange(FindObjectsOfType<SoundPrefs>());
        for (int i = 0; i < _sound.Count; i++)
        {
            _sound[i].PrefsChange();
        }
    }

    public void Sensitivity()
    {
        SensitivityParameter = _sensitivitySlider.value;
        PlayerPrefs.SetFloat("Sensitivity", SensitivityParameter);
    }

    public void FOV()
    {
        FOVParameter = Mathf.Clamp(180 * _fieldOfViewSlider.value, 10, 140);
        PlayerPrefs.SetFloat("FOV", FOVParameter);

        _camera.FOVChange();
    }
}