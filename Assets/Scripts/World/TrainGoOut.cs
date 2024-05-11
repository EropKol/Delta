using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrainGoOut : MonoBehaviour
{
    public Transform _train;
    private float _speed = 0.5f;

    private PlayerController _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            StartCoroutine(GoOut());

            FindObjectOfType<EnemySpawner>().OldTrainOut = true;
        }
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
