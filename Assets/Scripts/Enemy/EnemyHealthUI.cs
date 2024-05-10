using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public RawImage HealthBar;
    public GameObject UI;

    private HealthScript _enemyHeath;

    private void Start()
    {
        _enemyHeath = GetComponent<HealthScript>();
    }

    private void Update()
    {
        HealthBar.rectTransform.anchorMax = new Vector2(_enemyHeath.HealthPoints / _enemyHeath.MaxHealthPoints, 1);

        if(_enemyHeath.HealthPoints == 0)
        {
            UI.SetActive(false);
        }
    }
}
