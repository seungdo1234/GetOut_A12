using System.Collections;
using UnityEngine;

public class AutoScoutAttackHandler : TopDownShooting
{
    private Coroutine scoutAttackCoroutine;
    private CharacterStatHandler characterStat;

    private void Awake()
    {
        characterStat = GetComponent<CharacterStatHandler>();
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
        WaitForSeconds wait = new WaitForSeconds(characterStat.CurrentStat.AtkDelay);

        while (true)
        {
            if (characterStat.CurrentStat.EFlightStatus != EFlightStatus.Alive) break;
            
            Shooting(characterStat.CurrentStat, "EnemyBullet");
            yield return wait;
        }
    }
}