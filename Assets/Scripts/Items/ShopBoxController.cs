using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopBoxController : MonoBehaviour
{
    public PlayerController Player;
    public List<GameObject> ShopPoolWhite;
    public List<GameObject> ShopPoolGreen;
    public List<GameObject> ShopPoolRed;

    public float WhiteChance = 90;
    public float GreenChance = 10;
    public float RedChance = 1;


    public FlyingItem FlyingItemPrefab;

    public float EffectLength = 3;
    public float LookAngle = 20;
    public float ObjectScale = 0.8f;

    private float RandomNumber;

    private Outline _outline;
    private GameObject _item;
    private GameObject _itemPrefab;

    private BuyUI _playerUIScript;

    private void Start()
    {
        _outline = GetComponent<Outline>();

        RandomNumber = Random.Range(0, 1000);

        _playerUIScript = Player.GetComponent<BuyUI>();

        if (RandomNumber > 1000 - WhiteChance * 10) // > 100
        {
            _itemPrefab = ShopPoolWhite[Random.Range(0, ShopPoolWhite.Count)];
        }
        else
        {
            if (RandomNumber > RedChance * 10) // > 10; <= 100
            {
                _itemPrefab = ShopPoolGreen[Random.Range(0, ShopPoolGreen.Count)];
            }
            else
            {
                    _itemPrefab = ShopPoolRed[Random.Range(0, ShopPoolRed.Count)]; // <= 10
            }
        }

        _item = Instantiate(_itemPrefab, transform.position + 1.5f * Vector3.up, transform.rotation, gameObject.transform);

        _item.transform.localScale = new Vector3(ObjectScale, ObjectScale, ObjectScale);

        _item.GetComponent<ItemEffect>().Player = Player;
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
                FlyingItemObject.Player = Player;
            }
            _outline.OutlineWidth = 15;
        }
        else
        {
            _outline.OutlineWidth = 2;
        }
    }
}
