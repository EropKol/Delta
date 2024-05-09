using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image HealthBar;
    public TextMeshProUGUI HealthText;

    private HealthScript _playerHeath;

    private void Start()
    {
        _playerHeath = GetComponent<HealthScript>();
    }

    private void Update()
    {
        HealthBar.rectTransform.anchorMax = new Vector2(_playerHeath.HealthPoints / _playerHeath.MaxHealthPoints, 1);

        HealthText.text = _playerHeath.HealthPoints + " / " + _playerHeath.MaxHealthPoints;
    }
}
