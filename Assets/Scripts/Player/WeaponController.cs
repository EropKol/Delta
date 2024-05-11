using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public Transform ShotPoint;
    public BulletScript BulletPrefab;
    public Image SkillOne;

    public float DamageModifier = 1;
    public float CritChancePl = 0.01f;
    public float CritMultiplierPl = 2;
    public float RechargeTime = 1;
    public float ShotFlySpeedModifier = 1;

    public float ShotTimes = 1;
    public float XSpreadAngle = 0;
    public float YSpreadAngle = 0;
    public float ZSpreadAngle = 0;

    private float _rechargeTimer = 0;
    private Quaternion Spread =  Quaternion.Euler(0, 0, 0);

    public bool IsDeathEffect = false;

    private void Update()
    {
        ShotUpdate();

        RechargeTimerUpdate();

        ShotSkillUIUpdate();
    }

    void ShotUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && _rechargeTimer <= 0 && Time.timeScale != 0)
        {

            for (int i = 0; i < ShotTimes; i++)
            {
                if (ShotTimes > 1)
                {
                    Spread = Quaternion.Euler(XSpreadAngle * (2 * i / (ShotTimes - 1) - 1), YSpreadAngle * (2 * i / (ShotTimes - 1) - 1), ZSpreadAngle * (2 * i / (ShotTimes - 1) - 1));
                }

                SpawnBullet();
            }

            _rechargeTimer = RechargeTime;
        }
    }

    void RechargeTimerUpdate()
    {
        if (_rechargeTimer > 0)
        {
            _rechargeTimer -= Time.deltaTime;
        }
    }

    void ShotSkillUIUpdate()
    {
        SkillOne.fillAmount = 1 - _rechargeTimer / (RechargeTime);
    }

    void SpawnBullet()
    {
        var BulletObject = Instantiate(BulletPrefab, ShotPoint.position, ShotPoint.rotation * Spread);

        BulletObject.Damage *= DamageModifier * 40 * Random.Range(0.8f, 1.2f);
        BulletObject.ShotFlySpeed *= ShotFlySpeedModifier * Random.Range(0.5f, 1.5f);
        BulletObject.CritChance *= CritChancePl;
        BulletObject.CritMultiplier *= CritMultiplierPl;

        if (IsDeathEffect)
        {
            BulletObject.IsDeathEffect = true;
        }
    }
}
