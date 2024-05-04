using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingScript : MonoBehaviour
{
    public BulletScript BulletObject;

    private Vector3 Direction;

    private List<GameObject> Targets;

    private void Start()
    {
        Targets = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        transform.position = BulletObject.transform.position;

        foreach (var target in Targets)
        {
            if (target != gameObject)
            {
                Direction = target.transform.position - transform.position;

                BulletObject.HomingDirection(Direction);
            }
        }
    }

    private void Update()
    {
        if (BulletObject == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Targets.Add(other.gameObject);
        }
    }
}
