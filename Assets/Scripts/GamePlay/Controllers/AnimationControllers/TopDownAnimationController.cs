using UnityEngine;

public class TopDownAnimationController : MonoBehaviour
{
    protected TopDownController topDownController;
    protected Animator anim;

    protected virtual void Awake()
    {
        topDownController = GetComponent<TopDownController>();
        anim = GetComponent<Animator>();
    }
}
