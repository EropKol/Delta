using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool OldTrainOut;

    public List<Transform> SpawnPoints = new List<Transform>();
    public List<Transform> PatrolPoints = new List<Transform>();
    public EnemyAI EnemyPrefab;

    private float LevelsCompleted;
    private float _enemySpawnSpeed;

    private float _timer = 30;

    private TrainGoIn _train;

    void Start()
    {
        LevelsCompleted = PlayerPrefs.GetFloat("LevelsCompleted", 0);

        _enemySpawnSpeed = 5 * Mathf.Pow(0.9f, LevelsCompleted);

        _train = FindObjectOfType<TrainGoIn>();

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float wait = _enemySpawnSpeed;

        while (_timer > 0)
        {
            yield return new WaitForSeconds(_enemySpawnSpeed);

            for (int i = 0; i < LevelsCompleted + 1; i++)
            {
                var enemy = Instantiate(EnemyPrefab, SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Random.rotation);
                enemy.PatrolPoints = PatrolPoints;

                var health = enemy.GetComponent<HealthScript>();
                health.MaxHealthPoints *= Mathf.Pow(1.1f, LevelsCompleted);
                health.DeathCost *= Mathf.Pow(1.1f, LevelsCompleted);

                health.GetComponent<EnemyShootScript>().DamageMultiplier *= Mathf.Pow(1.1f, LevelsCompleted);
            }

            _timer -= _enemySpawnSpeed;
        }

        while (_train.IsMoving == false)
        {
            if (OldTrainOut == true)
            {
                _train.IsMoving = true;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
