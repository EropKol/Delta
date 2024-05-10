using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLevelScript : MonoBehaviour
{
    public GameObject Wall4;

    private float _timer = 5;
    private float _velocity = 10;
    private float _acceleration = 5.2f;

    private float _distance;
    private bool _isMoving = true;
    private EnemySpawner _spawner;

    private void Start()
    {
        _spawner = GetComponent<EnemySpawner>();
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            if (_timer >= 0)
            {
                _distance = -115 + (_velocity * _timer + (_acceleration * _timer * _timer) / 2);
            }
            else
            {
                _isMoving = false;
                _spawner.enabled = true;

                Wall4.SetActive(true);
            }

            transform.position = new Vector3(0, -2, _distance);

            _timer -= Time.deltaTime;
        }
    }
}
