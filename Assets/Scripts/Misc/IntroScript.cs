using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public RectTransform TextObject;

    private void Start()
    {
        StartCoroutine(Intro());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    private IEnumerator Intro()
    {
        while (TextObject.anchoredPosition.y < -535)
        {
            TextObject.anchoredPosition += new Vector2(TextObject.up.x * 0.01f, TextObject.up.y * 0.01f);

            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(3f);

        LoadMenu();
    }
}
