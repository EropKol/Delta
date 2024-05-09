using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnTime = 3;

    public List<Transform> SpawnPoints = new List<Transform>();
    public List<Transform> PatrolPoints = new List<Transform>();
    public EnemyAI EnemyPrefab;

    public float EnemyToNext;
    public float LevelsCompleted;
    private float _enemyCounter;

    private TrainGoIn _train;
    void Start()
    {
        EnemyToNext = 30 + 1.2f * LevelsCompleted;
        _train = FindObjectOfType<TrainGoIn>();

        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        if(_enemyCounter >= EnemyToNext)
        {
            _train.IsMoving = true;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        float wait = SpawnTime;

        while (enabled)
        {
            yield return new WaitForSeconds(wait);
            var enemy = Instantiate(EnemyPrefab, SpawnPoints[Random.Range(0, SpawnPoints.Count)].position, Random.rotation);
            enemy.PatrolPoints = PatrolPoints;

            _enemyCounter++;
        }
    }
}
