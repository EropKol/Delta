using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEvents : MonoBehaviour
{
    public BossAI Boss;
    public GameObject HealthUI;
    public Animator BossAnimator;

    private TrainGoOut _train;

    private void Start()
    {
        _train = FindObjectOfType<TrainGoOut>();
    }

    private void Update()
    {
        if(_train.OldTrainOut == true)
        {
            BossAnimator.SetTrigger("Start");

            Boss.enabled = true;
            HealthUI.SetActive(true);
        }
    }
}
