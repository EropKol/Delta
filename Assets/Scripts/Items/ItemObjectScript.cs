using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectScript : MonoBehaviour
{
    public GameObject Item;
    public PlayerController Player;

    private ItemEffect _itemEffect;

    private void Start()
    {
        var itemObject = Instantiate(Item, transform.position + Vector3.up, Quaternion.identity, gameObject.transform);

        itemObject.GetComponent<ItemEffect>().Player = Player;

        _itemEffect = itemObject.GetComponent<ItemEffect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _itemEffect.Use();

            Destroy(gameObject);
        }
    }
}
