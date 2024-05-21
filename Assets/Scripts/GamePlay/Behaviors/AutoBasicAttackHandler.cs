using System.Collections;
using UnityEngine;

public class AutoBasicAttackHandler : TopDownShooting
{
    private Coroutine scoutAttackCoroutine;
    private FlightStatHandler flightStat;

    private bool isBasicAttackLock;
    protected void Awake()
    {
        flightStat = GetComponent<FlightStatHandler>();
    }

    private void Start()
    {
        PlayAutoScoutAttack();
    }

    public void PlayAutoScoutAttack()
    {
        // 현재 비행기가 살아있는 경우에만 총기 발사
        if (scoutAttackCoroutine != null)
        {
            StopCoroutine(scoutAttackCoroutine);
        }

        scoutAttackCoroutine = StartCoroutine(AutoScoutAttackCoroutine());
    }
    private IEnumerator AutoScoutAttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(flightStat.CurrentStat.AtkDelay);

        while (flightStat.CurrentStat.EFlightStatus == EFlightStatus.Alive)
        {
            if (!isBasicAttackLock)
            {
                Shooting(flightStat.CurrentStat);
            }
            yield return wait;
        }
    }

    public void BasicAttackLock(bool isTrue) // 기본 공격 Lock
    {
        isBasicAttackLock = isTrue;
    }
}