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

    public PlayerController Player;
    private bool _playerNoticed;

    private NavMeshAgent _navMeshAgent;
    private EnemyShootScript _ShootScript;

    private void Start()
    {
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
        if(_playerNoticed == false)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                UpdateTargetPoint();
            }
        }
        else
        {
            _navMeshAgent.destination = Player.transform.position;

            if(EnemyType == 2)
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

        var direction = Player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _playerNoticed = true;

                }
            }
        }
    }
}
