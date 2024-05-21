using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ZapperEventHandler : SpecialWeaponController
{
    [SerializeField] private Zapper zapperProjectile;

    private AutoBasicAttackHandler autoBasicAttackHandler;
    [SerializeField]private float lazerTime;
    protected override void Awake()
    {
        base.Awake();
        autoBasicAttackHandler = topDownController.GetComponent<AutoBasicAttackHandler>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        topDownController.OnSpecialFireEvent += ZapperFireEvent;
        lazerTime = CurBulletCount;
    }

    private void ZapperFireEvent(bool isPress)
    {
        
        if (anim.GetBool(isSpecialFire) || !isDelay)
        {
            anim.SetBool(isSpecialFire, isPress);
            StartCoroutine(WaitSpecialWeaponDelayTime());
        }
    }

    private void FireZapper()
    {
        zapperProjectile.Init(specialWeaponData.atkPercent * FlightDataManager.Instance.PlayerFlightStat.CurrentStat.AtkDamage);
        zapperProjectile.gameObject.SetActive(true);
        autoBasicAttackHandler.BasicAttackLock(true);
        StartCoroutine(FireLaserCoroutine());
    }

    private void DisableZapper()
    {
        zapperProjectile.gameObject.SetActive(false);
        autoBasicAttackHandler.BasicAttackLock(false);
    }

    private IEnumerator FireLaserCoroutine()
    {
        while (zapperProjectile.gameObject.activeSelf)
        {
            lazerTime -= Time.deltaTime;
            if (lazerTime < 0)
            {
                topDownController.OnSpecialFireEvent -= ZapperFireEvent;
                gameObject.SetActive(false);
                break;
            }
            yield return null;
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StopCoroutine(FireLaserCoroutine());
    }
}