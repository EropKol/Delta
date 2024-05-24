using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public Animator AnimatorController;
    private bool SettingsOpened;
    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        _sound.Play();

        SceneManager.LoadScene(2);

        PlayerPrefs.SetFloat("LevelsCompleted", 0);
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

    public void ExitGame()
    {
        _sound.Play();

        Application.Quit();
    }
}
