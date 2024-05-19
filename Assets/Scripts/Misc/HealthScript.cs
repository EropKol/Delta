using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float HealthPoints;
    public float MaxHealthPoints = 100;
    public float HealthRegen = 1;
    public bool IsDead = false;

    private float _burningTimer;
    private float _freezeTimer;
    private float _poisonedTimer;

    public GameObject UIFire;
    public GameObject UIIce;
    public GameObject UIPoison;
    public TextMeshProUGUI UIFireTimer;
    public TextMeshProUGUI UIIceTimer;
    public TextMeshProUGUI UIPoisonTimer;

    public Animator Animator;
    public float DeathCost = 20;

    public ZoneScript ZoneEffect;

    private EnemyAI _AI;

    private MoneyScript _playersMoney;

    private float _timerMax = 1;
    private float _timer;

    private void Start()
    {
        _AI = GetComponent<EnemyAI>();

        _playersMoney = FindObjectOfType<MoneyScript>();

        HealthPoints = MaxHealthPoints;
    }

    public void DealDamage(float DamageDealt, bool IsDeathEffect = false, int DamageType = 0, float DeathEffectRadius = 7)
    {
        if (_AI != null)
        {
            _AI.PlayerNoticed = true;
        }

        HealthPoints -= DamageDealt;

        if (DamageType == 1)
        {
            Burning(1f);
        }

        if (DamageType == 2)
        {
            Freeze(3f);
        }

        if (DamageType == 3)
        {
            Poisoned(5f);
        }

        if (DamageType == 4)
        {
            HealthPoints -= DamageDealt * 0.2f;
        }

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
                zone.BurnTime = 3;
                zone.Size = DeathEffectRadius;
            }
        }
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = _timerMax;

            HealthPoints += HealthRegen * 1.5f;
            HealthPoints = Mathf.Clamp(HealthPoints, 0, MaxHealthPoints);
        }

        if (_burningTimer > 0)
        {
            _burningTimer -= Time.deltaTime;

            HealthPoints -= 6 * Time.deltaTime;

            UIFire.SetActive(true);

            UIFireTimer.text = Mathf.Round(_burningTimer).ToString();
        }
        else
        {
            UIFire.SetActive(false);
        }

        if (_freezeTimer > 0)
        {
            _freezeTimer -= Time.deltaTime;

            HealthPoints -= 4 * Time.deltaTime;

            UIIce.SetActive(true);

            UIIceTimer.text = Mathf.Round(_freezeTimer).ToString();
        }
        else
        {
            UIIce.SetActive(false);
        }

        if (_poisonedTimer > 0)
        {
            _poisonedTimer -= Time.deltaTime;

            HealthPoints -= 2 * Time.deltaTime;

            UIPoison.SetActive(true);

            UIPoisonTimer.text = Mathf.Round(_poisonedTimer).ToString();
        }
        else
        {
            UIPoison.SetActive(false);
        }

        if (HealthPoints <= 0)
        {
            DealDamage(0);
        }
    }

    public void Burning(float PlusTime)
    {
        _burningTimer += PlusTime;

    }

    public void Freeze(float PlusTime)
    {
        _freezeTimer += PlusTime;

    }

    public void Poisoned(float PlusTime)
    {
        _poisonedTimer += PlusTime;
            
    }

    void Destroy()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
