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
        // 현재 비행기가 살아있는 경우에만 총기 발사
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        attackCoroutine = StartCoroutine(AutoBasicAttackCoroutine());
    }
    private IEnumerator AutoBasicAttackCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(FlightDataManager.Instance.PlayerData.AtkDelay);
        
        while (true)
        {
            if (FlightDataManager.Instance.PlayerData.EFlightStatus != EFlightStatus.Alive) break;
            
            Shooting(FlightDataManager.Instance.PlayerData, "Bullet");
            yield return wait;
        }
        Debug.Log("Out");
    }

    private void ShootBullet()
    {

    }
}