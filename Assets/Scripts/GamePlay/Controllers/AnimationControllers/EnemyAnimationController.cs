using System;
using UnityEngine;

public class EnemyAnimationController : FlightAnimationController
{

    protected override void Awake()
    {
        base.Awake();
    }
    
    protected override void Start()
    {
        base.Start();
        healthSystem.OnDamage += TakeDamage;
    }

    private void TakeDamage()
    {
        anim.SetTrigger(Hit);
    }
    
}