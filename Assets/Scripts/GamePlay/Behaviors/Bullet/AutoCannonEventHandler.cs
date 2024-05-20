using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonEventHandler : SpecialWeaponController
{
    public int CurBulletCount { get; private set; }

    private void OnEnable()
    {
        isDelay = false;
        topDownController.OnSpecialFireEvent += SpecialFire;
        CurBulletCount = specialWeaponData.bulletCount;
    }

    private void SpecialFire()
    {
        if (!isDelay)
        {
            StartCoroutine(WaitSpecialWeaponDelayTime());
            anim.SetTrigger(isSpecialFire);
        }
    }

    private void FireAutoCannon() // 애니메이션 트리거
    {
        float damage = specialWeaponData.atkPercent * FlightDataManager.Instance.PlayerFlightStat.CurrentStat.AtkDamage;
        AutoCannonBullet autoCannon = GameManager.Instance.Pool.SpawnFromPool(EPoolObjectType.AutoCannon)
            .ReturnMyComponent<AutoCannonBullet>();

        autoCannon.transform.position = specialWeaponData.weaponPivots[CurBulletCount % 2].position;
        autoCannon.AutoCannonInit(damage, specialWeaponData.weaponSpeed);

        if (--CurBulletCount == 0)
        {
            topDownController.OnSpecialFireEvent -= SpecialFire;
            gameObject.SetActive(false);
        }
    }
}