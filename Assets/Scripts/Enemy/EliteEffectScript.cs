using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEffectScript : MonoBehaviour
{
    public int EliteType;
    // 0 - Normal, 1 - Fire, 2 - Ice, 3 - Earth, 4 - Air;

    private EnemyShootScript _ShootScript;

    public GameObject Model;

    public Material Fire;
    public Material Ice;
    public Material Earth;
    public Material Air;

    private void Start()
    {
        if (Random.Range(0, 100) > 90)
        {
            _ShootScript = GetComponent<EnemyShootScript>();
            _ShootScript.DamageMultiplier *= 2;

            var health = GetComponent<HealthScript>();
            health.MaxHealthPoints *= 2;
            health.HealthPoints *= 2;
            health.DeathCost *= 4;

            EliteType = Random.Range(1, 4);
            _ShootScript.DamageType = EliteType;

            if (EliteType == 1)
            {
                Model.GetComponent<Renderer>().material = Fire;
            }

            if (EliteType == 2)
            {
                Model.GetComponent<Renderer>().material = Ice;
            }

            if (EliteType == 3)
            {
                Model.GetComponent<Renderer>().material = Earth;
            }

            if (EliteType == 4)
            {
                Model.GetComponent<Renderer>().material = Air;
            }
        }
        else
        {
            GetComponent<EliteEffectScript>().enabled = false;
        }
    }
}
