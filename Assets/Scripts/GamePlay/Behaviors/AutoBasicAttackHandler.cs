using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBasicAttackHandler : TopDownShooting
{
    private Coroutine attackCoroutine;


    private void Start()
    {
        PlayAutoBasicAttack();
    }

    public void PlayAutoBasicAttack()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        attackCoroutine = StartCoroutine(AutoBasicAttackCoroutine());
    }
    private IEnumerator AutoBasicAttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(CharacterDataManager.Instance.PlayerData.AtkDelay);
        
        while (true)
        {
            Shooting(CharacterDataManager.Instance.PlayerData);
            yield return wait;
        }
    }

    private void ShootBullet()
    {
        
    }
}