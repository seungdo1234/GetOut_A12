using System.Collections;
using UnityEngine;

public class AutoScoutAttackHandler : TopDownShooting
{
    private Coroutine scoutAttackCoroutine;
    private FlightStatHandler flightStat;

    private void Awake()
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

        while (true)
        {
            if (flightStat.CurrentStat.EFlightStatus != EFlightStatus.Alive) break;
            
            Shooting(flightStat.CurrentStat, "EnemyBullet");
            yield return wait;
        }
    }
}