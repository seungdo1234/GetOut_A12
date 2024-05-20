using UnityEditor.Animations;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public virtual void BulletInit(float damage, float bulletSpeed, AnimatorOverrideController animator, LayerMask targetLayer) { }
    public virtual void BulletInit(float damage, float bulletSpeed, AnimatorController animator, LayerMask targetLayer) { }
    

}