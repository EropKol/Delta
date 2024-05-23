using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;

    private Rigidbody _rigidBody;
    private Vector3 _startDirection;
    private float _levelsCompleted;

    void Start()
    {
        _levelsCompleted = PlayerPrefs.GetFloat("LevelsCompleted", 5);

        _rigidBody = GetComponent<Rigidbody>();

        _startDirection = (transform.up * 3 + transform.forward) * 150;

        _rigidBody.AddForce(_startDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Boss")
        {
            Destroy(gameObject);

            var enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyAI>().BossLevel = true;

            var health = enemy.GetComponent<HealthScript>();
            health.MaxHealthPoints *= Mathf.Pow(1.1f, _levelsCompleted);
            health.DeathCost *= Mathf.Pow(1.1f, _levelsCompleted);

            enemy.GetComponent<EnemyShootScript>().DamageMultiplier *= Mathf.Pow(1.1f, _levelsCompleted);
        }
    }
}
