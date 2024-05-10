using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainGoIn : MonoBehaviour
{
    public GameObject Train;

    private float _timer = 7f;
    private float _velocity = 10;
    private float _acceleration = 5.2f;

    private float _distance;
    public bool IsMoving = false;

    void FixedUpdate()
    {
        if (IsMoving)
        {
            if (_timer >= 0)
            {
                _distance = -(_velocity * _timer + (_acceleration * _timer * _timer) / 2);
            }
            else
            {
                IsMoving = false;

                Train.transform.parent = null;
            }

            transform.position = new Vector3(0, 0, _distance);

            _timer -= Time.deltaTime;
        }
    }
}
