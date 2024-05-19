using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public float PlayersMoney = 0;

    public TextMeshProUGUI MoneyText;

    private void Update()
    {
        MoneyText.text = Mathf.Round(PlayersMoney).ToString();
    }
}
