using UnityEngine;

public class PlayerAnimationController : FlightAnimationController
{
    private readonly int isMoving = Animator.StringToHash("isMoving");
    private readonly int Hit = Animator.StringToHash("isInvisibility");
    
    protected override void Start()
    {
        base.Start();
        topDownController.OnMoveEvent += Move;
        healthSystem.OnDamage += TakeDamage;
    }
    
    private void Move(Vector2 direction)
    {
        anim.SetBool(isMoving, direction.magnitude != 0);
    }
    private void TakeDamage()
    {
        anim.SetTrigger(Hit);
    }
    
    private void InvisibilityOn()
    {
        gameObject.layer = 9;
    }
    private void InvisibilityOff()
    {
        gameObject.layer = 6;
    }
}