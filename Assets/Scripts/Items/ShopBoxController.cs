using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopBoxController : MonoBehaviour
{
    public PlayerController Player;
    public List<GameObject> ShopPool;
    public FlyingItem FlyingItemPrefab;

    public float EffectLength = 3;
    public float LookAngle = 20;
    public float ObjectScale = 0.8f;

    private Outline _outline;
    private GameObject _item;
    private GameObject _itemPrefab;

    private void Start()
    {
        _outline = GetComponent<Outline>();

        _itemPrefab = ShopPool[Random.Range(0, ShopPool.Count)];

        _item = Instantiate(_itemPrefab, transform.position + 1.5f * Vector3.up, transform.rotation, transform);

        _item.transform.localScale = new Vector3(ObjectScale, ObjectScale, ObjectScale);
    }

    private void Update()
    {
        var DistanceToPlayer = transform.position - Player.transform.position;

        if (Vector3.Angle(Player.transform.forward, DistanceToPlayer) < LookAngle && Vector3.Magnitude(DistanceToPlayer) < EffectLength)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(_item);
                GetComponent<ShopBoxController>().enabled = false;
                GetComponent<Outline>().enabled = false;

                var FlyingItemObject = Instantiate(FlyingItemPrefab, transform.position + Vector3.up * 2f, transform.rotation);
                FlyingItemObject.ChosenItem = _itemPrefab;
            }
            _outline.OutlineWidth = 15;
        }
        else
        {
            _outline.OutlineWidth = 2;
        }
    }
}
