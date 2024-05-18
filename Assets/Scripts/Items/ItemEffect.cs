using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public int ItemID;

    private PlayerController _player;
    private PlayerItemScript _playerItemScript;
    private ItemNotification _notify;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        _playerItemScript = _player.GetComponent<PlayerItemScript>();

        _notify = _player.GetComponent<ItemNotification>();
    }

    public void Use()
    {
        _playerItemScript.ItemIDList[ItemID]++;

        _notify.ItemsOrder.Add(ItemID);

        _playerItemScript.Recalculate();
    }
}
