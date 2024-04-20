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
    public float RechargeTime = 1;
    public float ShotFlySpeedModifier = 1;

    private float _rechargeTimer = 0;

    private void Update()
    {
        SkillOne.fillAmount = 1 - _rechargeTimer / (RechargeTime * 5);

        if (Input.GetKey(KeyCode.Mouse0) && _rechargeTimer <= 0)
        {
            var BulletObject = Instantiate(BulletPrefab, ShotPoint.position, ShotPoint.rotation);
            BulletObject.Damage = DamageModifier * 10;
            BulletObject.ShotFlySpeed = ShotFlySpeedModifier * 10;

            _rechargeTimer = RechargeTime * 5;
        }

        if(_rechargeTimer > 0)
        {
            _rechargeTimer -= Time.deltaTime;
        }
    }
}
