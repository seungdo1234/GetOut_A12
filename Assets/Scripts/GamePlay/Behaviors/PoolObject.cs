using UnityEngine;

public abstract class PoolObject : MonoBehaviour
{
    public abstract void BulletInit(float damage ,float bulletSpeed , LayerMask targetLayer);
    
}