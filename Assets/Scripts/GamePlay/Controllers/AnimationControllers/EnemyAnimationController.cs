using System;
using UnityEngine;

public class EnemyAnimationController : TopDownAnimationController
{
    private readonly int Dead = Animator.StringToHash("Dead");

    private HealthSystem healthSystem;
    protected override void Awake()
    {
        base.Awake();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        if(healthSystem != null)
        {
            healthSystem.OnDeath += Death;
        }
    }

    private void Death()
    {
        anim.SetTrigger(Dead);
    }
}