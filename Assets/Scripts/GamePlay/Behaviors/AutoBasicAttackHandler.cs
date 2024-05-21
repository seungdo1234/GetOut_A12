using System.Collections;
using UnityEngine;

public class AutoBasicAttackHandler : TopDownShooting
{
    private Coroutine attackCoroutine;

    private bool isBasicAttackLock;
    private void Start()
    {
        PlayAutoBasicAttack();
    }

    public void PlayAutoBasicAttack()
    {
        // 이미 코루틴이 실행중이라면 중지하고 다시 시작 (겹치는 것 방지)
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        attackCoroutine = StartCoroutine(AutoBasicAttackCoroutine());
    }
    private IEnumerator AutoBasicAttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(flightStat.CurrentStat.AtkDelay);

        while (flightStat.CurrentStat.EFlightStatus == EFlightStatus.Alive)
        {
            Shooting(flightStat.CurrentStat);
            yield return wait;
        }
    }

    public void BasicAttackLock(bool isTrue)
    {
        isBasicAttackLock = isTrue;
    }
}
