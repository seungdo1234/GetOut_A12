using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{

    private void OnMove(InputValue inputValue)
    {
        Vector2 dir = inputValue.Get<Vector2>().normalized;
        CallMoveEvent(dir);
        
    }
}
