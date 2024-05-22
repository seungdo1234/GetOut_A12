using System;
using UnityEditor.Animations;
using UnityEngine;
[Serializable]
public class FlightStat
{
    [Header("# Flight Stat")]
    public float MoveSpeed;
    public float AtkDelay;
    public float AtkDamage;
    public float MaxHealth;
    public int BulletNum;
    public float BulletAngle;
    public float BulletSpeed;
    public EFlightStatus EFlightStatus;

    [Header("# Bullet Animator")]
    public RuntimeAnimatorController BulletAnimator;
}
