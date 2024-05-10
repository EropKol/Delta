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

    public Animator Animator;
    public float DeathCost = 20;

    public ZoneScript ZoneEffect;

    private EnemyAI _AI;

    private MoneyScript _playersMoney;

    private float _timerMax = 3;
    private float _timer;

    private void Start()
    {
        _AI = GetComponent<EnemyAI>();

        _playersMoney = FindObjectOfType<MoneyScript>();

        HealthPoints = MaxHealthPoints;
    }

    public void DealDamage(float DamageDealt, bool IsDeathEffect = false)
    {
        if (_AI != null)
        {
            _AI.PlayerNoticed = true;
        }

        HealthPoints -= DamageDealt;

        if (HealthPoints <= 0)
        {
            _playersMoney.PlayersMoney += DeathCost;
            HealthPoints = 0;

            IsDead = true;
            Animator.SetBool("IsDead", true);
            Invoke("Destroy", 1);


            if (IsDeathEffect)
            {
                var zone = Instantiate(ZoneEffect, transform.position, Quaternion.identity);
                zone.Mode = 2;
            }
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = _timerMax;

            HealthPoints += HealthRegen;
            HealthPoints = Mathf.Clamp(HealthPoints, 0, MaxHealthPoints);

            if (BurningTimer > 0)
            {
                BurningTimer -= Time.deltaTime;

                HealthPoints -= 15 * Time.deltaTime;
            }

            if (HealthPoints == 0)
            {
                DealDamage(0);
            }
        }

        HealthPoints = Mathf.Round(HealthPoints);
    }

    public void Burning(float PlusTime)
    {
        BurningTimer += PlusTime;

    }

    void Destroy()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
