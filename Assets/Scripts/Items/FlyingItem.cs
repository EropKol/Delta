using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingItem : MonoBehaviour
{
    public ItemObjectScript ItemPrefab;
    public GameObject BoughtItem;

    private Rigidbody _rigidBody;
    private Vector3 _startDirection;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _startDirection = (Vector3.up * 3 + Vector3.forward) * 100;

        _rigidBody.AddForce(_startDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);

        Destroy(gameObject);

        var ItemObject = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
        ItemObject.IsBought = true;
        ItemObject.Item = BoughtItem;
    }
}
