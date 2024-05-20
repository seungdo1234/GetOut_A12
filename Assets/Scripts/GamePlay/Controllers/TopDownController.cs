using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnSpecialFireEvent;

    public void CallMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }
    
    public void CallSpecialFireEvent()
    {
        OnSpecialFireEvent?.Invoke();
    } 
}
