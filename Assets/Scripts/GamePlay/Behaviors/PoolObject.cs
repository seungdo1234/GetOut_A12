using UnityEditor.Animations;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public virtual void BulletInit(float damage, float bulletSpeed, RuntimeAnimatorController animator, LayerMask targetLayer) { }

} 