using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float HealthPoints;
    public float MaxHealthPoints = 100;
    public bool IsDead = false;

    public float BurningTimer;

    private void Start()
    {
        HealthPoints = MaxHealthPoints;
    }

    public void DealDamage(float DamageDealt)
    {
        HealthPoints -= DamageDealt;

        if (HealthPoints < 0)
        {
            HealthPoints = 0;

            IsDead = true;
        }
    }

    private void Update()
    {
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
