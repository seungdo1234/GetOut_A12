using UnityEditor.Animations;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
<<<<<<< Updated upstream
    public virtual void BulletInit(float damage, float bulletSpeed, AnimatorOverrideController animator, LayerMask targetLayer) { }
    public virtual void BulletInit(float damage, float bulletSpeed, AnimatorController animator, LayerMask targetLayer) { }
    

}
=======
    // PoolObject를 상속받는 자식 클래스로 다운 캐스팅
    public T ReturnMyConponent<T>() where T : PoolObject
    {
        return this as T;
    }
} 
>>>>>>> Stashed changes
