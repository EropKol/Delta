using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float TimeToExplode;
    public float ExplosionDamage;

    public GameObject Zone;

    private void Start()
    {
        Invoke("Explode", TimeToExplode);

        ExplosionDamage = GetComponent<BulletScript>().Damage;
    }

    void Explode()
    {
        var zone = Instantiate(Zone, transform.position, Quaternion.identity);
        zone.GetComponent<ZoneScript>().ExplosionDamage = ExplosionDamage;

        Destroy(gameObject);
    }
}
