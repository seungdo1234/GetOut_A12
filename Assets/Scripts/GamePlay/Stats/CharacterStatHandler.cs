using System.Collections.Generic;
using UnityEngine;

// 변동되는 스텟에 대한 관리
public class CharacterStatHandler : MonoBehaviour
{
    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; }
    public List<CharacterStat> statModifiers = new List<CharacterStat>();

    private void Awake()
    {
        InitCharacterStat();        
    }
    private void OnEnable()
    {
        InitCharacterStat();
    }
    private void InitCharacterStat()
    {
        CurrentStat = new CharacterStat();
        CurrentStat.MoveSpeed = baseStat.MoveSpeed;
        CurrentStat.AtkDelay = baseStat.AtkDelay;
        CurrentStat.MaxHealth = baseStat.MaxHealth;
        CurrentStat.BulletNum = baseStat.BulletNum;
        CurrentStat.BulletAngle = baseStat.BulletAngle;
        CurrentStat.BulletSpeed = baseStat.BulletSpeed;
        CurrentStat.EFlightStatus= baseStat.EFlightStatus;
    }

    public void Death()
    {
        CurrentStat.EFlightStatus = EFlightStatus.Dead;
    }
}

