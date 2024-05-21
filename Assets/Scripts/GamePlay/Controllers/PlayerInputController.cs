using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    
    
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>().normalized;
        CallMoveEvent(dir);
    }

    public void OnSpecialFire(InputAction.CallbackContext context)
    {
        if(context.phase != InputActionPhase.Performed)
        {
            CallSpecialFireEvent(context.phase == InputActionPhase.Started);   
        }
    }
}