using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IDOnTop : MonoBehaviour
{
    public TextMeshProUGUI Text;

    private void Start()
    {
        Text.text = GetComponentInChildren<ItemEffect>().ItemID.ToString();
    }
}
