using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour
{
    public GameObject Train;
    public List<ShopBoxController> Shops = new List<ShopBoxController>();
    public List<Canvas> ItemCosts = new List<Canvas>();
    public int _nextScene = 2;

    private GameObject _player;
    private GameObject _nextLevelUI;
    private bool _inExitArea = false;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject;

        _nextLevelUI = FindObjectOfType<PointerNextLevel>().gameObject;

        _nextLevelUI.SetActive(false);
    }

    private void Update()
    {
        if (_inExitArea && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LoadScene());

            for (int i = 0; i < Shops.Count; i++)
            {
                Shops[i].enabled = false;
                ItemCosts[i].enabled = false;
            }
        }
    }

    public IEnumerator LoadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextScene, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(_player, SceneManager.GetSceneByBuildIndex(_nextScene));
        SceneManager.MoveGameObjectToScene(Train, SceneManager.GetSceneByBuildIndex(_nextScene));
        SceneManager.UnloadSceneAsync(currentScene);
        _nextLevelUI.SetActive(false);
        if (_nextScene == 3)
        {
            _nextScene = 2;

            TurnOn();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void TurnOn()
    {
        for (int i = 0; i < Shops.Count; i++)
        {
            Shops[i].enabled = true;
            ItemCosts[i].enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _inExitArea = true;

        _nextLevelUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _inExitArea = false;

        _nextLevelUI.SetActive(false);
    }
}
