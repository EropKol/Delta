using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    private PlayerController _player;
    private HealthScript _health;
    private NavMeshAgent _navMeshAgent;
    private BossAttack _attackScript;
    private AudioSource _audio;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        _navMeshAgent = GetComponent<NavMeshAgent>();

        _health = GetComponent<HealthScript>();
    
        _attackScript = GetComponent<BossAttack>();

        _audio = GetComponent<AudioSource>();

        _audio.Play();
    }

    private void Update()
    {
        PatrolUpdate();

        IsDeadCheckUpdate();
    }

    void IsDeadCheckUpdate()
    {
        if (_health.IsDead)
        {
            _navMeshAgent.enabled = false;
            _health.enabled = false;
            _attackScript.enabled = false;
            GetComponent<BossAI>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    void PatrolUpdate()
    {
        if (_attackScript.IsRolling == false)
        {
            _navMeshAgent.destination = _player.transform.position;
        }
    }
}
