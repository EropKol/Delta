using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IDOnTop : MonoBehaviour // Prototype Only
{
    public TextMeshProUGUI Text;

    private void Update()
    {
        Text.text = GetComponentInChildren<ItemEffect>().ItemID.ToString();
    }
}
