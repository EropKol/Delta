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

    private float _speed = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GoOut());
    }

    private IEnumerator GoOut()
    {
        while (World.position.z >= -215)
        {
            World.position -= _speed * World.forward;

            yield return new WaitForSeconds(0.001f);
        }

        StartCoroutine(NextLevelScript.LoadScene());

        TrainGoOut1.SetActive(true);
        gameObject.SetActive(false);
    }
}
