using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUnloader : MonoBehaviour
{
    void Update()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if(player != null)
        {
            Invoke("Unload", 0.5f);
        }
    }

    void Unload()
    {
        SceneManager.UnloadSceneAsync("LevelOne");
        Destroy(gameObject);
    }
}
