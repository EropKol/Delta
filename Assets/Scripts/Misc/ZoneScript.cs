using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
    public float ExplosionDamage;
    public float Size = 7.5f;

    public int Mode = 1;

    public float BurnTime;

    private float _timeToFade = 1;
    private Renderer _renderer;

    private float _timeToEnd = 0.1f;
    private bool _active = true;

    private void Start()
    {
        transform.localScale *= Size;

        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (_timeToEnd > 0)
        {
            _timeToEnd -= Time.deltaTime;
        }

        if (_timeToEnd < 0)
        {
            _active = false;
        }


        _timeToFade -= Time.deltaTime;

        _renderer.material.color = new Color(1, 1, 1, 0.28f * _timeToFade);

        if(_timeToFade < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_active == true)
        {
            var health = GetComponent<HealthScript>();
            if (health != null)
            {
                if (Mode == 1)
                {
                    health.DealDamage(ExplosionDamage);
                }

                if (Mode == 2)
                {
                    health.Burning(BurnTime);
                }
            }
        }
    }
}
