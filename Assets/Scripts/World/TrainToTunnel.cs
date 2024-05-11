using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainToTunnel : MonoBehaviour
{
    public ToNextLevel NextLevelScript;
    public Transform World;
    public GameObject TrainGoOut1;
    public bool GoingOut2;

    private float _speed = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (GoingOut2 == false)
        {
            StartCoroutine(GoOut());

            GoingOut2 = true;
        }
    }

    private IEnumerator GoOut()
    {
        while (World.position.z >= -215)
        {
            World.position -= _speed * World.forward;

            yield return new WaitForSeconds(0.001f);
        }

        StartCoroutine(NextLevelScript.LoadScene(3, gameObject));

        TrainGoOut1.SetActive(true);
    }
}
