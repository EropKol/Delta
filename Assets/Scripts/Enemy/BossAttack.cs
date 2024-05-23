using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack : MonoBehaviour
{
    public float AttackDistance;
    public Transform EnemySource;

    public bool IsRolling;
    public Animator BossAnimator;
    public FlyingEnemy FlyingEnemy;
    private NavMeshAgent _navMeshAgent;
    private PlayerController _player;
    private HealthScript _playerHealth;

    private float _toPlayerDistance;

    private float _rollTimer;
    private float _closeTimer;
    private float _spawnTimer;
    private float _maxRollTimer = 15;
    private float _maxCloseTimer = 1f;
    private float _maxSpawnTimer = 30f;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _player = FindObjectOfType<PlayerController>();

        _playerHealth = _player.GetComponent<HealthScript>();

        _rollTimer = _maxRollTimer;
        _closeTimer = _maxCloseTimer;
        _spawnTimer = _maxSpawnTimer;
    }

    private void Update()
    {
        _toPlayerDistance = Vector3.Magnitude(_player.transform.position - transform.position);

        _rollTimer -= Time.deltaTime;
        _closeTimer -= Time.deltaTime;
        _spawnTimer -= Time.deltaTime;

        if (_rollTimer <= 0)
        {
            _rollTimer = _maxRollTimer;

            StartCoroutine(RollingAttack());
        }

        if (_closeTimer <= 0)
        {
            _closeTimer = _maxCloseTimer;

            StartCoroutine(CloseAttack());
        }

        if (_spawnTimer <= 0)
        {
            _spawnTimer = _maxSpawnTimer;

            SpawnAttack();
        }
    }

    private IEnumerator RollingAttack()
    {
        IsRolling = true;
        BossAnimator.SetTrigger("IsRolling");

        _navMeshAgent.angularSpeed = 0;

        _navMeshAgent.SetDestination(transform.forward * 5);

        yield return new WaitForSeconds(1f);

        IsRolling = false;
        _navMeshAgent.angularSpeed = 180;
    }

    private IEnumerator CloseAttack()
    {
        if (_toPlayerDistance <= AttackDistance)
        {
            yield return new WaitForSeconds(1f);

            if (_toPlayerDistance <= AttackDistance)
            {
                _playerHealth.DealDamage(0, false, 5);
            }
        }
    }

    private void SpawnAttack()
    {
        for (int i = 0; i < 5; i++)
        {
            var CurrentAngle = Quaternion.Euler(0, i * 360 / 5, 0);

            Instantiate(FlyingEnemy, EnemySource.position, EnemySource.rotation * CurrentAngle);
        }
    }
}
