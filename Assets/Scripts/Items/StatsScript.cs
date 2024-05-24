using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsScript : MonoBehaviour
{
    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI CritChance;
    public TextMeshProUGUI CritDamage;

    private PlayerController _player;
    private WeaponController _weapon;
    private HealthScript _health;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        _weapon = _player.GetComponent<WeaponController>();

        _health = _player.GetComponent<HealthScript>();
    }

    private void Update()
    {
        Attack.text = _weapon.DamageModifier.ToString();

        Defence.text = _health.Defence.ToString();

        Speed.text = _player.RunningSpeed.ToString();

        CritChance.text = _weapon.CritChancePl.ToString();

        CritDamage.text = _weapon.CritMultiplierPl.ToString();
    }
}
