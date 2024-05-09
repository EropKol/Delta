using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrainGoOut : MonoBehaviour
{
    public Transform _train;
    private float _speed = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GoOut());
    }

    private IEnumerator GoOut()
    {
        while (_train.position.z <= 100)
        {
            _train.position += _speed * _train.forward;

            yield return new WaitForSeconds(0.001f);
        }

        Destroy(_train.gameObject);
    }
}
