using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float HealthPoints;
    public float MaxHealthPoints = 100;
    public float HealthRegen = 1;
    public bool IsDead = false;

    public float BurningTimer;

    public ZoneScript ZoneEffect;

    private void Start()
    {
        HealthPoints = MaxHealthPoints;
    }

    public void DealDamage(float DamageDealt, bool IsDeathEffect = false)
    {
        HealthPoints -= DamageDealt;

        if (HealthPoints < 0)
        {
            HealthPoints = 0;

            IsDead = true;

            if (IsDeathEffect)
            {
                var zone = Instantiate(ZoneEffect, transform.position, Quaternion.identity);
                zone.Mode = 2;
            }
        }
    }

    private void Update()
    {
        HealthPoints += HealthRegen * Time.deltaTime;
        HealthPoints = Mathf.Clamp(HealthPoints, 0, MaxHealthPoints);

        if (BurningTimer > 0)
        {
            BurningTimer -= Time.deltaTime;

            HealthPoints -= 15 * Time.deltaTime;
        }
    }

    public void Burning(float PlusTime)
    {
        BurningTimer += PlusTime;

    }
}
