using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathScript : MonoBehaviour
{
    public GameObject UI;
    public GameObject GameOverUI;

    private HealthScript _health;
    private bool _isGameOver;

    private void Start()
    {
        _health = GetComponent<HealthScript>();
    }

    private void Update()
    {
        if(_health.IsDead == true)
        {
            _isGameOver = true;

            UI.SetActive(false);

            _health.enabled = false;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<PlayerItemScript>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<CameraController>().enabled = false;
            GetComponent<MoneyScript>().enabled = false;
            GetComponent<WeaponController>().enabled = false;
        }

        if(_isGameOver == true)
        {
            GameOverUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
