using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    public BulletScript Bullet;
    public Transform BulletSourse;

    public float RechargeTimer = 3;
    private float _timer;

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
            var bullet = Instantiate(Bullet, BulletSourse.position, direction);
            
            bullet.Damage *= 10 * Random.Range(0.8f, 1.2f);
            bullet.ShotFlySpeed *= Random.Range(0.5f, 1.5f);
            bullet.CritChance *= 10;
            bullet.CritMultiplier *= 2;

            _timer = RechargeTimer;
        }
    }
}
