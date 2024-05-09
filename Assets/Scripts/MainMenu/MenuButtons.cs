using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public RectTransform SettingsUI;
    private bool SettingsOpened;

    private void FixedUpdate()
    {
        if (SettingsOpened)
        {
            if(SettingsUI.anchoredPosition.x > 500)
            {
                SettingsUI.anchoredPosition = new Vector2(SettingsUI.anchoredPosition.x - 200, 0);
            }
        }
        else
        {
            if (SettingsUI.anchoredPosition.x < 1400)
            {
                SettingsUI.anchoredPosition = new Vector2(SettingsUI.anchoredPosition.x + 200, 0);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        if (SettingsOpened)
        {
            SettingsOpened = false;
        }
        else
        {
            SettingsOpened = true;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
