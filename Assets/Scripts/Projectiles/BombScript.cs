using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float TimeToExplode;

    private void Start()
    {
        Invoke("Explode", TimeToExplode);
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
