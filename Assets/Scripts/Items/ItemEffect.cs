using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public int ItemID;

    private PlayerController _player;
    private PlayerItemScript _playerItemScript;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        _playerItemScript = _player.GetComponent<PlayerItemScript>();
    }

    public void Use()
    {
        _playerItemScript.ItemIDList[ItemID]++;

        _playerItemScript.Recalculate();
    }
}
