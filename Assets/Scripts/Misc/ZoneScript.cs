using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
    public float ExplosionDamage;
    public float Size = 10f;

    public int Mode = 1;

    public float BurnTime = 3;

    private float _timeToFade = 1;
    private Renderer _renderer;

    private float _timeToEnd = 0.1f;
    private bool _active = true;

    private Collider[] colliders;

    private void Start()
    {
        transform.localScale *= Size;

        _renderer = GetComponent<Renderer>();

        colliders = Physics.OverlapSphere(transform.position, Size);

        foreach (Collider collider in colliders)
        {
            Explosion(collider);
        }
    }

    private void Update()
    {
        EffectTimer();

        VisualTimer();
    }

    private void Explosion(Collider other)
    {
        if (_active == true)
        {
            var health = other.GetComponent<HealthScript>();
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

    void EffectTimer()
    {
        if (_timeToEnd > 0)
        {
            _timeToEnd -= Time.deltaTime;
        }

        if (_timeToEnd < 0)
        {
            _active = false;
        }
    }

    void VisualTimer()
    {
        _timeToFade -= Time.deltaTime;

        _renderer.material.color = new Color(1, 1, 1, 0.28f * _timeToFade);

        if (_timeToFade < 0)
        {
            Destroy(gameObject);
        }
    }
}
