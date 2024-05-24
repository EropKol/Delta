using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainToTunnel : MonoBehaviour
{
    public ToNextLevel NextLevelScript;
    public GameObject Train;
    public Transform World;
    public GameObject TrainGoOut1;
    public bool GoingOut2;

    private float _speed = 0.5f;
    private GameObject _player;


    private void Start()
    {
        _player = FindObjectOfType<PlayerController>().gameObject;

        var levelPlus = PlayerPrefs.GetFloat("LevelsCompleted", 0) + 1;

        PlayerPrefs.SetFloat("LevelsCompleted", levelPlus);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            if (GoingOut2 == false)
            {
                StartCoroutine(GoOut());

                Train.transform.parent = null;

                GoingOut2 = true;
            }
        }
    }

    private IEnumerator GoOut()
    {
        while (World.position.z >= -215)
        {
            World.position -= _speed * World.forward;

            yield return new WaitForSeconds(0.001f);
        }

        StartCoroutine(NextLevelScript.LoadScene(4, gameObject));

        TrainGoOut1.SetActive(true);
    }
}
