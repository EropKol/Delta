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
        transform.LookAt(_playerTransform.position + Vector3.up * 1.5f);
    }
}
