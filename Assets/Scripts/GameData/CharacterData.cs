using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterData : MonoBehaviour, IDamageable
{
    [Header("# Character Stat")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float atkDelay;
    [SerializeField] private float atkDamage;
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;
    [SerializeField] private int bulletNum;
    [SerializeField] private float bulletAngle;
    [SerializeField] private float bulletSpeed;
    
    public enum MyEnum
    {
        Hit,Dead = 100,Leveliup
    }

    public MyEnum e;
    
    public float MoveSpeed => moveSpeed;
    public float AtkDamage => atkDamage;
    public float AtkDelay => atkDelay;
    public int BulletNum => bulletNum;
    public float BulletAngle => bulletAngle;
    public float BulletSpeed => bulletSpeed;

    private void Awake()
    {
        TakeDamage(1.5f);
    }

    public void TakeDamage(float damage)
    {
        if (curHealth - damage > 0)
        {
            curHealth -= damage;   
        }
        else
        {
            // 게임오버
        }
    }
}