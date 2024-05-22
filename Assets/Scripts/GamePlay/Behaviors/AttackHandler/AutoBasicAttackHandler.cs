using System.Collections;
using UnityEngine;

public class AutoBasicAttackHandler : TopDownShooting
{
    [SerializeField] private AttackSO attackSO;
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
        WaitForSeconds wait = new WaitForSeconds(attackSO.AtkDelay);

        while (flightStat.CurrentStat.EFlightStatus == EFlightStatus.Alive)
        {
            if (!isBasicAttackLock)
            {
                AudioManager.instance.PlaySfx(Sfx.PlayerAtk);
                Shooting(attackSO);   
            }
            yield return wait;
        }
    }

    public void BasicAttackLock(bool isTrue)
    {
        isBasicAttackLock = isTrue;
    }
}