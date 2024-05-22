using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack : MonoBehaviour
{
    public float AttackDistance;

    public bool IsRolling;
    public Animator BossAnimator;
    public FlyingItem FlyingEnemy;
    private NavMeshAgent _navMeshAgent;
    private PlayerController _player;
    private HealthScript _playerHealth;

    private float _toPlayerDistance;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _player = FindObjectOfType<PlayerController>();

        _playerHealth = _player.GetComponent<HealthScript>();

        StartCoroutine(CloseAttack());

        StartCoroutine(RollingAttack());

        StartCoroutine(SpawnAttack());
    }

    private void Update()
    {
        _toPlayerDistance = Vector3.Magnitude(_player.transform.position - transform.position);
    }

    private IEnumerator RollingAttack()
    {
        while (enabled == true)
        {
            IsRolling = true;
            BossAnimator.SetTrigger("IsRolling");

            _navMeshAgent.angularSpeed = 0;

            _navMeshAgent.SetDestination(transform.forward * 5);

            yield return new WaitForSeconds(1f);

            IsRolling = false;
            _navMeshAgent.angularSpeed = 180;

            yield return new WaitForSeconds(15f);
        }
    }

    private IEnumerator CloseAttack()
    {
        while (enabled == true)
        {
            if (_toPlayerDistance <= AttackDistance)
            {
                yield return new WaitForSeconds(0.5f);

                if (_toPlayerDistance <= AttackDistance)
                {
                    _playerHealth.DealDamage(0, false, 5);
                }
            }
        }
    }

    private IEnumerator SpawnAttack()
    {
        while (enabled == true)
        {
            yield return new WaitForSeconds(30f);

            for(int i = 0;  i < 5; i++)
            {
                var CurrentAngle = Quaternion.Euler(0, i * 360 / 5, 0);

                var enemy = Instantiate(FlyingEnemy, transform.position + Vector3.up * 5, CurrentAngle);
            }
        }
    }
}
