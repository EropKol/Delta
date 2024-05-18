using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        transform.forward = - _playerTransform.forward;
    }
}
