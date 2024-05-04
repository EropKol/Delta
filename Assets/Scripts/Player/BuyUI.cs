using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyUI : MonoBehaviour
{
    public GameObject UIObject;

    public float UseDistance = 2.5f;
    private void Update()
    {
        UIObject.SetActive(false);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.25f, transform.forward, out hit))
        {
            if (hit.collider.tag == "Shop" && hit.distance <= UseDistance)
            {
                UIObject.SetActive(true);
            }
        }
    }
}