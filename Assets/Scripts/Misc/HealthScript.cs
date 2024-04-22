using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float HealthPoints = 100;
    public bool IsDead = false;

    public void DealDamage(float DamageDealt)
    {
        HealthPoints -= DamageDealt;

        if (HealthPoints < 0)
        {
            HealthPoints = 0;

            IsDead = true;
        }
    }
}
