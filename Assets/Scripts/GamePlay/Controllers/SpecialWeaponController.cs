using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeaponController : MonoBehaviour
{
   [SerializeField] protected SpecialWeaponData specialWeaponData;
   protected Animator anim;
   protected TopDownController topDownController;
   protected readonly int isSpecialFire = Animator.StringToHash("isSpecialFire");
   protected bool isDelay;
   private WaitForSeconds waitDelayTime;
   
   protected virtual void Awake()
   {
      topDownController = transform.root.GetComponent<TopDownController>();
      anim = GetComponent<Animator>();
      waitDelayTime = new WaitForSeconds(specialWeaponData.weaponAtkDelay);
   }
   
   protected IEnumerator WaitSpecialWeaponDelayTime()
   {
      isDelay = true;
      yield return waitDelayTime;
      isDelay = false;
   }

}
