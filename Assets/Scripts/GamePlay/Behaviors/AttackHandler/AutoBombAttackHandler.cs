using System;
using System.Collections;
using UnityEngine;

public class AutoBombAttackHandler : TopDownShooting
{
    private Coroutine attackCoroutine;
    [SerializeField] private float bombSpeed;
    [SerializeField] private float explodeDelay;
    
    private void Start()
    {
        PlayAutoBombAttack();
    }

    private void PlayAutoBombAttack()
    {
        // 이미 코루틴이 실행중이라면 중지하고 다시 시작 (겹치는 것 방지)
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        attackCoroutine = StartCoroutine(AutoBombAttackCoroutine());
    }

    private IEnumerator AutoBombAttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(flightStat.CurrentStat.AtkDelay);
        while (flightStat.CurrentStat.EFlightStatus == EFlightStatus.Alive)
        {
            Bombing(flightStat.CurrentStat, bombSpeed, explodeDelay);
            yield return wait;
        }
    }
}
