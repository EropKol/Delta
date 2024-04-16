using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectScript : MonoBehaviour
{
    public List<GameObject> Pool;

    public bool IsBought = false;
    public GameObject Item;

    private void Start()
    {
        if (!IsBought)
        {
            Instantiate(Pool[Random.Range(0, Pool.Count)], transform.position + Vector3.up, Quaternion.identity, gameObject.transform);
        }
        else
        {
            Instantiate(Item, transform.position + Vector3.up, Quaternion.identity, gameObject.transform);
        }
    }
}
