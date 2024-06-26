using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    public RectTransform CreditsObject;
    public Animator BGAnimator;
    public Animator TextAnimator;

    private PlayerDeathScript _player;

    private AudioSource _audio;

    private void Start()
    {
        _player = FindObjectOfType<PlayerDeathScript>();
        
        _audio = GetComponent<AudioSource>();
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
        _player.GetComponent<AudioSource>().Pause();

        _audio.Play();

        _player.UIOff();

        CreditsObject.gameObject.SetActive(true);

        BGAnimator.SetTrigger("Start");

        while(CreditsObject.anchoredPosition.y <= 2000)
        {
            CreditsObject.anchoredPosition += new Vector2(0, 2f);

            if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                CreditsObject.anchoredPosition += new Vector2(0, 8f);
            }

            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(5f);

        TextAnimator.SetTrigger("Fade");

        yield return new WaitForSeconds(1f);

        _audio.Pause();

        _player.IsWin = true;
    }
}
