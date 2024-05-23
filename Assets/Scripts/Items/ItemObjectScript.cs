using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectScript : MonoBehaviour
{
    public GameObject Item;

    private ItemEffect _itemEffect;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();

        var itemObject = Instantiate(Item, transform.position + Vector3.up, Quaternion.identity, gameObject.transform);

        _itemEffect = itemObject.GetComponent<ItemEffect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _itemEffect.Use();

            _audio.Play();

            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        _itemEffect.gameObject.SetActive(false);

        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
