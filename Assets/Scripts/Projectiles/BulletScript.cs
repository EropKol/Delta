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

    public bool IsHoming = false;
    public float HomingSpeed = 0.5f;
    public float HomingRadius = 0.5f;

    public HomingScript HomingZoneObject;

    public bool IsDeathEffect = false;

    private Rigidbody _rigidBody;

    private void Start()
    {
        Invoke("BulletDie", 15);

        _rigidBody = GetComponent<Rigidbody>();

        _rigidBody.AddForce(transform.forward * 100 * ShotFlySpeed + transform.up * 100 * TurnUp);

        if (IsHoming)
        {
            var homingZone = Instantiate(HomingZoneObject, transform);
            homingZone.GetComponent<SphereCollider>().radius = HomingRadius;
            homingZone.BulletObject = gameObject.GetComponent<BulletScript>();
        }
    }

    public void HomingDirection(Vector3 Direction)
    {
        _rigidBody.AddForce(Direction * HomingSpeed);
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
                health.DealDamage(Damage, IsDeathEffect);
            }
            else
            {
                health.DealDamage(Damage * CritMultiplier, IsDeathEffect);
            }
        }
    }

    void BulletDie()
    {
        Destroy(gameObject);
    }
}