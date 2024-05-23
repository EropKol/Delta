using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ShopBoxController : MonoBehaviour
{
    public List<GameObject> ShopPoolWhite;
    public List<GameObject> ShopPoolGreen;
    public List<GameObject> ShopPoolRed;

    public float ItemCost = 20;

    public float WhiteChance = 90;
    public float GreenChance = 10;
    public float RedChance = 1;


    public FlyingItem FlyingItemPrefab;

    public float EffectLength = 3;
    public float LookAngle = 20;
    public float ObjectScale = 0.8f;

    private float RandomNumber;

    public TextMeshProUGUI _UIText;

    private Outline _outline;
    private GameObject _item;
    private GameObject _itemPrefab;

    private MoneyScript _moneyScript;

    private PlayerController _player;

    private AudioSource _audio;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();

        _moneyScript = _player.GetComponent<MoneyScript>();

        _audio = GetComponent<AudioSource>();

        _outline = GetComponent<Outline>();

        RandomNumber = Random.Range(0, 1000);

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

        _UIText.text = "$ " + ItemCost;
    }

    private void Update()
    {
        if (_moneyScript.PlayersMoney >= ItemCost)
        {
            var DistanceToPlayer = transform.position - _player.transform.position;

            if (Vector3.Angle(_player.transform.forward, DistanceToPlayer) < LookAngle && Vector3.Magnitude(DistanceToPlayer) < EffectLength)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(_item);

                    _moneyScript.PlayersMoney -= ItemCost;

                    ItemCost *= 2;

                    _audio.Play();

                    var FlyingItemObject = Instantiate(FlyingItemPrefab, transform.position + Vector3.up * 2f, transform.rotation);
                    FlyingItemObject.ChosenItem = _itemPrefab;

                    Start();
                }
                _outline.OutlineWidth = 15;
            }
            else
            {
                _outline.OutlineWidth = 2;
            }
        }
        else
        {
            _outline.OutlineWidth = 2;
        }
    }
}
