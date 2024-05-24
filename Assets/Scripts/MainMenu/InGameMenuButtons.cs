using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuButtons : MonoBehaviour
{
    public GameObject MenuObject;
    public Animator AnimatorController;
    private bool SettingsOpened;
    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        _sound.Play();

        Time.timeScale = 1.0f;

        MenuObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void Options()
    {
        _sound.Play();

        if (SettingsOpened)
        {
            SettingsOpened = false;
            AnimatorController.SetBool("IsOpened", false);
        }
        else
        {
            SettingsOpened = true;
            AnimatorController.SetBool("IsOpened", true);
        }
    }

    public void ExitToMenu()
    {
        _sound.Play();

        SceneManager.LoadScene(1);

        Time.timeScale = 1;
    }
}
