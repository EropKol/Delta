using System.Collections.Generic;
using UnityEngine;

public class PlayerItemScript : MonoBehaviour
{
    public bool ReCalculate;
    // ForTestOnly

    public List<int> ItemIDList;
    public List<ItemEffect> ItemNameList;

    public BulletScript Bomb;
    public BulletScript Bullet;

    public FlyingItem FlyingItemPrefab;
    public List<GameObject> Pool10;
    public List<GameObject> Pool11;

    private PlayerController _player;
    private WeaponController _weapon;
    private DodgeScript _dodgeScript;
    private HealthScript _health;

    private float ItemDropperCounter10 = 0;
    private float ItemDropperCounter11 = 0;

    private void Start()
    {
        _player = GetComponent<PlayerController>();

        _weapon = GetComponent<WeaponController>();

        _dodgeScript = GetComponent<DodgeScript>();

        _health = GetComponent<HealthScript>();
    }

    private void Update()
    {
        if (ReCalculate)
        {
            Recalculate();
            ReCalculate = false;
        }
    }

    public void Recalculate()
    {
        // Damage

        _weapon.DamageModifier = 1 + 0.2f * ItemIDList[1]; // 1 BulletItem (White)

        // Critical Hits

        _weapon.CritChancePl = 0.01f + 0.1f * ItemIDList[6]; // 6 Glasses (White)

        _weapon.CritMultiplierPl = 2 + 0.5f * ItemIDList[7]; // 7 Bead (Green)

        // Shot Speed

        _weapon.RechargeTime = 1 * Mathf.Pow(0.9f, ItemIDList[3]); // 3 Magazine (Green)

        // Speed

        _player.WalkingSpeed = 1 * Mathf.Pow(1.1f, ItemIDList[4]);  // 4 Black Shoe (White)

        _player.RunningSpeed = 1.75f * Mathf.Pow(1.15f, ItemIDList[5]); // 5 White Shoe (White)

        // Projectile Change

        if (ItemIDList[2] > 0) // 2 Bomb (Red)
        {
            _weapon.BulletPrefab = Bomb;

            _weapon.RechargeTime = 2.25f + 0.25f * ItemIDList[2];
            Bomb.Damage = 3.9f + 0.1f * ItemIDList[2];
        }
        else
        {
            _weapon.BulletPrefab = Bullet;
        }

        _player.JumpModifier = 1 + Mathf.Pow(1.3f, ItemIDList[14]); // 14 Green Shoes (Green)
        

        // Spread

        if (ItemIDList[8] > 0) // 8 TriHat (Red)
        {
            _weapon.YSpreadAngle = 100 * (0.3f + 0.1f * ItemIDList[8] / (ItemIDList[8] + 1));
            _weapon.ShotTimes = 1 + 1 * ItemIDList[8];
        }

        // DeathEffects

        if (ItemIDList[12] > 0) // 12 Gasoline (White)
        {
            _weapon.IsDeathEffect = true;

            _weapon.DeathEffectRadius = 6 + 1 * ItemIDList[12];

        }

        // Misc

        _dodgeScript.DodgeChance = 0 + 100 * (0.1f * ItemIDList[9] / (0.1f * ItemIDList[9] + 1)); // 9 Mirror (White)

        if (ItemIDList[10] > 0) // 10 Present (Green)
        {
            ItemDropperCounter10++;
            for (int i = 0; i < 1 + 2 * ItemDropperCounter10; i++)
            {
                var CurrentAngle = Quaternion.Euler(0, i * 360 / (1 + ItemDropperCounter10), 0);

                var itemObject = Instantiate(FlyingItemPrefab, transform.position, transform.rotation * CurrentAngle);

                itemObject.ChosenItem = Pool10[Random.Range(0, Pool10.Count)];
            }

            ItemIDList[10]--;
        }

        if (ItemIDList[11] > 0) // 11 SpecialPresent (Red)
        {
            ItemIDList[11]--;
            ItemDropperCounter11++;
            for (int i = 0; i < 1 + ItemDropperCounter11; i++)
            {
                var CurrentAngle = Quaternion.Euler(0, i * 360 / (1 + ItemDropperCounter11), 0);

                var itemObject = Instantiate(FlyingItemPrefab, transform.position + Vector3.up * 2f, transform.rotation * CurrentAngle);

                itemObject.ChosenItem = Pool11[Random.Range(0, Pool11.Count)];
            }
        }

        _health.HealthRegen = 0.5f + 0.25f * ItemIDList[13]; // 13 Bread (Green)
    }
}
