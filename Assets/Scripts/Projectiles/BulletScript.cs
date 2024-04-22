using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Damage;
    public float CritChance = 1;
    public float CritMultiplier = 1;
    public float ShotFlySpeed = 1;

    private void Start()
    {
        Invoke("BulletDie", 15);

        GetComponent<Rigidbody>().AddForce(transform.forward * 100 * ShotFlySpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletDie();

        var DodgeScript = other.GetComponent<DodgeScript>();

        if (DodgeScript != null)
        {
            if (Random.Range(0, 100) > DodgeScript.DodgeChance)
            {
                DealDamage(other);
            }
        }
        else
        {
            DealDamage(other);
        }
    }

    void DealDamage(Collider other)
    {
        var health = other.gameObject.GetComponent<HealthScript>();
        if (health != null)
        {
            if (Random.Range(0, 100) > 100 * CritChance)
            {
                health.DealDamage(Damage);
            }
            else
            {
                health.DealDamage(Damage * CritMultiplier);
            }
        }
    }

    void BulletDie()
    {
        Destroy(gameObject);
    }
}