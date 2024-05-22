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
    public bool IsMoving = true;

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            if (_timer >= 0)
            {
                _distance = -115 + (_velocity * _timer + (_acceleration * _timer * _timer) / 2);
            }
            else
            {
                IsMoving = false;

                Wall4.SetActive(true);
            }

            transform.position = new Vector3(0, -2, _distance);

            _timer -= Time.deltaTime;
        }
    }
}
