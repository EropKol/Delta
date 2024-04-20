using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Damage;
    public float ShotFlySpeed;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * ShotFlySpeed * 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        var health = other.gameObject.GetComponent<HealthScript>();
        if(health != null)
        {
            health.DealDamage(Damage);
        }
    }
}
