using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [Header("# Character Stat")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float atkDelay;
    [SerializeField] private float atkDamage;
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;

    public float MoveSpeed => moveSpeed;
    
    public void OnDamaged(float damage)
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