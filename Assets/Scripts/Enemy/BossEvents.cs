using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvents : MonoBehaviour
{
    public BossAI Boss;
    public GameObject HealthUI;
    public Animator BossAnimator;

    public GameObject Exit;

    private TrainGoOut _train;
    private bool _notRepeat;
    private bool _end;

    private void Start()
    {
        _train = FindObjectOfType<TrainGoOut>();
    }

    private void Update()
    {
        if(_train.OldTrainOut == true)
        {
            StartCoroutine(Initialize());

            _train.OldTrainOut = false;

            _end = true;
        }

        if(Boss.enabled == false && _notRepeat == false && _end == true)
        {
            _notRepeat = true;

            StartCoroutine(Ending());
        }
    }

    private IEnumerator Initialize()
    {
        BossAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(2f);

        Boss.enabled = true;
        Boss.GetComponent<BossAttack>().enabled = true;
        HealthUI.SetActive(true);
    }

    private IEnumerator Ending()
    {
        while(Exit.transform.position.y <= 12)
        {
            Exit.transform.position += Vector3.up * 0.05f;

            yield return new WaitForSeconds(0.01f);
        }
    }
}
