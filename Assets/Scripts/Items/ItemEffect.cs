using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public int ItemID;

    public PlayerController Player;

    private PlayerItemScript _playerItemScript;

    private void Start()
    {
        _playerItemScript = Player.GetComponent<PlayerItemScript>();
    }

    public void Use()
    {
        _playerItemScript.ItemIDList[ItemID]++;

        _playerItemScript.Recalculate();
    }
}
