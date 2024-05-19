using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    public BulletScript Bullet;
    public Transform BulletSource;

    public float RechargeTimer = 3;
    private float _timer;

    public float DamageMultiplier;
    public int DamageType = 0;
    // 0 - Nothing, 1 - Fire, 2 - Ice, 3 - Earth, 4 - Air;

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
    }

    public void Shoot(Quaternion direction)
    {
        if (_timer <= 0)
        {
            var bullet = Instantiate(Bullet, BulletSource.position, direction);

            bullet.DamageType = DamageType;
            bullet.Damage *= DamageMultiplier * 10 * Random.Range(0.8f, 1.2f);
            bullet.ShotFlySpeed *= Random.Range(0.5f, 1.5f);
            bullet.CritChance *= 10;
            bullet.CritMultiplier *= 2;

            _timer = RechargeTimer;
        }
    }
}
