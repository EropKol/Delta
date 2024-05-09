using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int EnemyType;
    // 1 - Fighter, 2 - Shooter

    public List<Transform> PatrolPoints;
    public float ViewAngle;

    private PlayerController _player;
    private bool _playerNoticed;
    private Vector3 _direction;

    private NavMeshAgent _navMeshAgent;
    private EnemyShootScript _ShootScript;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        _navMeshAgent = GetComponent<NavMeshAgent>();

        _ShootScript = GetComponent<EnemyShootScript>();

        UpdateTargetPoint();
    }

    private void Update()
    {
        PlayerNoticeUpdate();

        PatrolUpdate();
    }

    void PatrolUpdate()
    {
        if (_playerNoticed == false)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                UpdateTargetPoint();
            }
        }
        else
        {
            if (_navMeshAgent.remainingDistance >= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.destination = _player.transform.position;
            }
            else
            {
                _navMeshAgent.destination = -_direction.normalized * _navMeshAgent.stoppingDistance + _player.transform.position;

                transform.LookAt(_player.transform);
            }

            if (EnemyType == 2)
            {
                _ShootScript.Shoot(transform.rotation);
            }
        }
    }

    void UpdateTargetPoint()
    {
        _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
    }

    void PlayerNoticeUpdate()
    {
        _playerNoticed = false;

        _direction = _player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, _direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, _direction, out hit))
            {
                if (hit.collider.gameObject == _player.gameObject)
                {
                    _playerNoticed = true;

                }
            }
        }
    }
}
