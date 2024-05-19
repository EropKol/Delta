using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Damage;
    public float CritChance = 1;
    public float CritMultiplier = 1;
    public float ShotFlySpeed = 1;
    public float TurnUp = 0;

    public bool IsDeathEffect = false;
    public float DeathEffectRadius = 7;

    public int DamageType = 0;
    // 0 - Nothing, 1 - Fire, 2 - Ice, 3 - Earth, 4 - Air;

    private Rigidbody _rigidBody;

    private void Start()
    {
        Invoke("BulletDie", 15);

        _rigidBody = GetComponent<Rigidbody>();

        _rigidBody.AddForce(transform.forward * 100 * ShotFlySpeed + transform.up * 100 * TurnUp);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Bullet")
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
    }

    void DealDamage(Collider other)
    {
        var health = other.gameObject.GetComponent<HealthScript>();
        if (health != null)
        {
            if (Random.Range(0, 100) > 100 * CritChance)
            {
                health.DealDamage(Damage, IsDeathEffect, DamageType, DeathEffectRadius);
            }
            else
            {
                health.DealDamage(Damage * CritMultiplier, IsDeathEffect, DamageType, DeathEffectRadius);
            }
        }
    }

    void BulletDie()
    {
        Destroy(gameObject);
    }
}