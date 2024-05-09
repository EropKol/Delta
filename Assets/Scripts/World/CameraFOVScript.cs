using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOVScript : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    public void FOVChange()
    {
        _camera.fieldOfView = PlayerPrefs.GetFloat("FOV", 60);
    }

}
