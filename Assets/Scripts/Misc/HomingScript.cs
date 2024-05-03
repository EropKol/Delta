using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingScript : MonoBehaviour
{
    public BulletScript BulletObject;

    private Vector3 Direction;

    private List<GameObject> Targets;
    private EnemyAI _enemyAI;

    private void Start()
    {
        Targets.Add(gameObject);
    }

    private void Update()
    {
        foreach (var target in Targets)
        {
            if (target != gameObject)
            {
                Direction = target.transform.position - transform.position;

                BulletObject.HomingDirection(Direction);
            }
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<EnemyAI>(out _enemyAI);
        if (_enemyAI != null)
        {
            Targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Targets.Remove(other.gameObject);
    }
}
