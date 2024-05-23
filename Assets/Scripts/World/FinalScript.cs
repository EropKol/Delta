using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    public RectTransform CreditsObject;
    public Animator BGAnimator;
    public Animator TextAnimator;

    private PlayerDeathScript _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerDeathScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Credits());
        }
    }

    private IEnumerator Credits()
    {
        _player.UIOff();

        CreditsObject.gameObject.SetActive(true);

        BGAnimator.SetTrigger("Start");

        while(CreditsObject.anchoredPosition.y <= 1000)
        {
            CreditsObject.anchoredPosition += new Vector2(0, 1f);

            if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                CreditsObject.anchoredPosition += new Vector2(0, 4f);
            }

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(5f);

        TextAnimator.SetTrigger("Fade");

        yield return new WaitForSeconds(1f);

        _player.IsWin = true;
    }
}
