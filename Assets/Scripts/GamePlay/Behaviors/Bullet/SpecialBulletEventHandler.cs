using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletEventHandler : SpecialWeaponController
{

    protected override void OnEnable()
    {
        base.OnEnable();
        topDownController.OnSpecialFireEvent += SpecialBulletFireEvent;
    }

    private void SpecialBulletFireEvent()
    {
        if (!isDelay)
        {
            StartCoroutine(WaitSpecialWeaponDelayTime());
            anim.SetTrigger(isSpecialFire);
        }
    }

    private void FireSpecialBullet() // 애니메이션 이벤트
    {
        float damage = specialWeaponData.atkPercent * FlightDataManager.Instance.PlayerFlightStat.CurrentStat.AtkDamage;
        SpecialBullet special = GameManager.Instance.Pool.SpawnFromPool(EPoolObjectType.SpecialBullet)
            .ReturnMyComponent<SpecialBullet>();

        special.transform.position = specialWeaponData.weaponPivots[CurBulletCount % specialWeaponData.bulletsPerShot].position;
        special.SpecialBulletInit(damage, specialWeaponData.weaponSpeed , specialWeaponData.bulletAnimator);

        if (--CurBulletCount == 0)
        {
            topDownController.OnSpecialFireEvent -= SpecialBulletFireEvent;
            gameObject.SetActive(false);
        }
    }
}