using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public int EnemyType;
    // 1 - Fighter, 2 - Shooter;

    public List<Transform> PatrolPoints = new List<Transform>();
    public float ViewAngle;

    public bool BossLevel;

    public bool PlayerNoticed;
    private PlayerController _player;
    private Vector3 _direction;

    private HealthScript _health;
    private NavMeshAgent _navMeshAgent;
    private EnemyShootScript _ShootScript;

    private AudioSource _audio;
    private bool _audioPlays;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        _navMeshAgent = GetComponent<NavMeshAgent>();

        _health = GetComponent<HealthScript>();

        _ShootScript = GetComponent<EnemyShootScript>();

        UpdateTargetPoint();

        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayerNoticeUpdate();

        PatrolUpdate();

        IsDeadCheckUpdate();
    }

    void IsDeadCheckUpdate()
    {
        if (_health.IsDead)
        {
            _navMeshAgent.enabled = false;
            _ShootScript.enabled = false;
            _health.enabled = false;
            GetComponent<EnemyAI>().enabled = false;
        }
    }

    void PatrolUpdate()
    {
        if (PlayerNoticed == false && BossLevel == false)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                UpdateTargetPoint();
            }

            if (_audioPlays == false)
            {
                _audio.Play();
                _audioPlays = true;
            }
        }
        else
        {
            if (_navMeshAgent.remainingDistance >= _navMeshAgent.stoppingDistance)
            {
                _navMeshAgent.destination = _player.transform.position;

                if (_audioPlays == false)
                {
                    _audio.Play();
                    _audioPlays = true;
                }
            }
            else
            {
                _navMeshAgent.destination = -_direction.normalized * _navMeshAgent.stoppingDistance + _player.transform.position;

                transform.LookAt(_player.transform);

                _audio.Pause();
                _audioPlays = false;
            }

            if (EnemyType == 2)
            {
                _ShootScript.Shoot(transform.rotation);
            }
        }
    }

    void UpdateTargetPoint()
    {
        if (PatrolPoints != null)
        {
            _navMeshAgent.destination = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
        }
    }

    void PlayerNoticeUpdate()
    {
        PlayerNoticed = false;

        _direction = _player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, _direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, _direction, out hit))
            {
                if (hit.collider.gameObject == _player.gameObject)
                {
                    PlayerNoticed = true;

                }
            }
        }
    }
}
