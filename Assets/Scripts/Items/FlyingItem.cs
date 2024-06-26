using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingItem : MonoBehaviour
{
    public ItemObjectScript ItemPrefab;
    public GameObject ChosenItem;

    public float Force = 150;

    private Rigidbody _rigidBody;
    private Vector3 _startDirection;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _startDirection = (transform.up * 3 + transform.forward) * Force;

        _rigidBody.AddForce(_startDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        var ItemObject = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
        ItemObject.Item = ChosenItem;
    }
}
