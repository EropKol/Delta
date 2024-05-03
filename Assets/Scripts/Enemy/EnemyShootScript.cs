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
            Instantiate(Bullet, BulletSourse.position, direction);

            _timer = RechargeTimer;
        }
    }
}
