using UnityEngine;

public class FlightAnimationController : TopDownAnimationController
{
    private readonly int isMoving = Animator.StringToHash("isMoving");

    private void Start()
    {
        topDownController.OnMoveEvent += Move;
    }
    
    private void Move(Vector2 direction)
    {
        anim.SetBool(isMoving, direction.magnitude != 0);
    }
    
}