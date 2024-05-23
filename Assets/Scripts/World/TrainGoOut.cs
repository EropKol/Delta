using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrainGoOut : MonoBehaviour
{
    public Transform _train;
    public bool OldTrainOut;

    private float _speed = 0.5f;

    private PlayerController _player;
    private EnemySpawner _spawner;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _spawner = FindObjectOfType<EnemySpawner>();

        if (other.gameObject == _player.gameObject)
        {
            if (_spawner != null)
            {
                _spawner.OldTrainOut = true;
            }
            OldTrainOut = true;

            StartCoroutine(GoOut());
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
