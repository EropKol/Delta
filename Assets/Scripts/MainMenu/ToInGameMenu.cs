using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToInGameMenu : MonoBehaviour
{
    public GameObject MenuObject;

    void Update()
    {
        if (MenuObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;

                MenuObject.SetActive(true);


                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
        }
    }
}
