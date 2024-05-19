using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public Animator AnimatorController;
    private bool SettingsOpened;

    public void StartGame()
    {
        SceneManager.LoadScene(1);

        PlayerPrefs.SetFloat("LevelsCompleted", 0);
    }

    public void Options()
    {
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
        Application.Quit();
    }
}
