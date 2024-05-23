using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour
{
    public GameObject Train;
    public List<ShopBoxController> Shops = new List<ShopBoxController>();
    public List<GameObject> ItemCosts = new List<GameObject>();
    public int _nextScene = 2;

    public int _bossScene = 4;

    private GameObject _player;
    private GameObject _nextLevelUI;
    private GameObject _bossLevelUI;
    private bool _readyForBoss = false;
    private bool _inExitArea = false;

    private AudioSource _audio;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject;

        _nextLevelUI = FindObjectOfType<PointerNextLevel>().gameObject;

        _bossLevelUI = FindObjectOfType<PointerBossLevel>().transform.GetChild(0).gameObject;

        _audio = GetComponent<AudioSource>();

        _nextLevelUI.SetActive(false);

        _bossLevelUI.SetActive(false);

        if (PlayerPrefs.GetFloat("LevelsCompleted", 0) >= 5)
        {
            _readyForBoss = true;
        }
    }

    private void Update()
    {
        if (_inExitArea && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LoadScene(_nextScene, gameObject));

            for (int i = 0; i < Shops.Count; i++)
            {
                Shops[i].enabled = false;
                ItemCosts[i].SetActive(false);
            }
        }

        if (_inExitArea && Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(LoadScene(_bossScene, gameObject));

            for (int i = 0; i < Shops.Count; i++)
            {
                Shops[i].enabled = false;
                ItemCosts[i].SetActive(false);
            }
        }
    }

    public IEnumerator LoadScene(int NextScene, GameObject Activator)
    {
        _audio.Play();

        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NextScene, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(_player, SceneManager.GetSceneByBuildIndex(NextScene));
        SceneManager.MoveGameObjectToScene(Train, SceneManager.GetSceneByBuildIndex(NextScene));
        SceneManager.UnloadSceneAsync(currentScene);
        _nextLevelUI.SetActive(false);
        _bossLevelUI.SetActive(false);
        if (NextScene == 3)
        {
            TurnOn();
        }
        Destroy(Activator);

    }

    private void TurnOn()
    {
        for (int i = 0; i < Shops.Count; i++)
        {
            Shops[i].enabled = true;
            ItemCosts[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _inExitArea = true;

            _nextLevelUI.SetActive(true);

            if (_readyForBoss)
            {
                _bossLevelUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _inExitArea = false;

        _nextLevelUI.SetActive(false);

        _bossLevelUI.SetActive(false);
    }
}
