using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathScript : MonoBehaviour
{
    public GameObject UI;
    public GameObject GameOverUI;
    public GameObject WinUI;
    public bool IsWin;

    private HealthScript _health;
    private bool _isGameOver;

    private void Start()
    {
        _health = GetComponent<HealthScript>();
    }

    public void UIOff()
    {
        UI.SetActive(false);

        _health.enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerItemScript>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<MoneyScript>().enabled = false;
        GetComponent<WeaponController>().enabled = false;
    }

    private void Update()
    {
        if(_health.IsDead == true)
        {
            _isGameOver = true;

            UIOff();
        }

        if(_isGameOver == true)
        {
            GameOverUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(1);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(2);

                PlayerPrefs.SetFloat("LevelsCompleted", 0);
            }
        }

        if (IsWin == true)
        {
            WinUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(1);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
