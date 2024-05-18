using System.Collections;
using UnityEngine;

public class AutoScoutAttackHandler : TopDownShooting
{
    private Coroutine scoutAttackCoroutine;


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
        WaitForSeconds wait = new WaitForSeconds(CharacterDataManager.Instance.Enemy1ScoutData.AtkDelay);

        while (true)
        {
            if (CharacterDataManager.Instance.Enemy1ScoutData.EFlightStatus != EFlightStatus.Alive) break;
            
            Shooting(CharacterDataManager.Instance.Enemy1ScoutData, "EnemyBullet");
            yield return wait;
        }
    }
}