using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : MonoBehaviour
{
    protected TopDownController topDownController;
    protected Animator anim;

    private void Awake()
    {
        topDownController = GetComponent<TopDownController>();
        anim = GetComponent<Animator>();
    }
}