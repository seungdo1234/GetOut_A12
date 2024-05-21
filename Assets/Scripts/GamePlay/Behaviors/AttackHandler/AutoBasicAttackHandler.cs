using System.Collections;
using UnityEngine;

public class AutoBasicAttackHandler : TopDownShooting
{
    private Coroutine attackCoroutine;
    private FlightStatHandler flightStat;

    protected void Awake()
    {
        flightStat = GetComponent<FlightStatHandler>();
    }

    private void Start()
    {
        PlayAutoBasicAttack();
    }

    public void PlayAutoBasicAttack()
    {
        // 현재 비행기가 살아있는 경우에만 총기 발사
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
}
