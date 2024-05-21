using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTorpedoAttackHandler : TopDownShooting
{
    [SerializeField] private List<Transform> firePositions;
    private Coroutine attackCoroutine;

    private void Start()
    {
        PlayAutoTorpedoAttack();
    }

    private void PlayAutoTorpedoAttack()
    {
        // 이미 코루틴이 실행중이라면 중지하고 다시 시작 (겹치는 것 방지)
        if(attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        attackCoroutine = StartCoroutine(AutoTorpedoAttackCoroutine());
    }

    private IEnumerator AutoTorpedoAttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(flightStat.CurrentStat.AtkDelay);
        while (flightStat.CurrentStat.EFlightStatus == EFlightStatus.Alive)
        {
            // firePoints들을 순회하면서 발사
            foreach(Transform firePosition in firePositions)
            {
                Shooting(flightStat.CurrentStat, firePosition);
                yield return wait;
            }
        }
    }
}