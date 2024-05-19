using System.Collections.Generic;
using UnityEngine;

// 변동되는 스텟에 대한 관리
public class FlightStatHandler : MonoBehaviour
{
    [SerializeField] private FlightStat baseStat;
    public FlightStat CurrentStat { get; private set; }
    public List<FlightStat> statModifiers = new List<FlightStat>();

    private void Awake()
    {
        InitFlightStat();        
    }
    private void OnEnable()
    {
        InitFlightStat();
    }
    private void InitFlightStat()
    {
        CurrentStat = new FlightStat();
        CurrentStat.MoveSpeed = baseStat.MoveSpeed;
        CurrentStat.AtkDelay = baseStat.AtkDelay;
        CurrentStat.AtkDamage = baseStat.AtkDamage;
        CurrentStat.MaxHealth = baseStat.MaxHealth;
        CurrentStat.BulletNum = baseStat.BulletNum;
        CurrentStat.BulletAngle = baseStat.BulletAngle;
        CurrentStat.BulletSpeed = baseStat.BulletSpeed;
        CurrentStat.EFlightStatus= baseStat.EFlightStatus;
        CurrentStat.BulletAnimator = baseStat.BulletAnimator;
        CurrentStat.BulletOverrideAnimator = baseStat.BulletOverrideAnimator;
    }

    public void Death()
    {
        CurrentStat.EFlightStatus = EFlightStatus.Dead;
    }
}

