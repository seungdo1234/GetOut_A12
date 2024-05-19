using System;
using UnityEngine;
[Serializable]
public class CharacterStat
{
    [Header("# Character Stat")]
    public float MoveSpeed;
    public float AtkDelay;
    [Range(1f,1f)]public float AtkDamage;
    [Range(0f, 100f)]public float MaxHealth;
    [Range(1, 100)] public int BulletNum;
    [Range(0f, 360f)] public float BulletAngle;
    [Range(1f, 20f)] public float BulletSpeed;
    public EFlightStatus EFlightStatus;
}
