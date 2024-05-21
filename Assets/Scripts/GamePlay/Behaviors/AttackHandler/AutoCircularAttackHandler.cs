using System.Collections;
using UnityEngine;

public class AutoCircularAttackHandler : TopDownShooting
{
    [SerializeField] private float anglePerFire;
    private float curAngle = 0f;
    private float div = 360f;
    private Coroutine attackCoroutine;
    
    private void Start()
    {
        PlayAutoCircularAttack();
    }

    private void PlayAutoCircularAttack()
    {
        // 이미 코루틴이 실행중이라면 중지하고 다시 시작 (겹치는 것 방지)
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        attackCoroutine = StartCoroutine(AutoCircularAttackCoroutine());
    }

    private IEnumerator AutoCircularAttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(flightStat.CurrentStat.AtkDelay);
        while (flightStat.CurrentStat.EFlightStatus == EFlightStatus.Alive)
        {
            Shooting(flightStat.CurrentStat, curAngle);
            curAngle = (curAngle - anglePerFire) % div;
            yield return wait;
        }
    }
}