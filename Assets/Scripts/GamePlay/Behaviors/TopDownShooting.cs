using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class TopDownShooting : MonoBehaviour
{
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private LayerMask targetLayer;
    
    protected void Shooting(CharacterData characterData)
    {
        // 몇 도 만큼 각도를 띄울건지
        float projectilesAngleSpace = characterData.BulletAngle;
        // 한 번에 몇발 나갈 건지
        int numberOfProjectilePerShot = characterData.BulletNum;
        
        // 최소 각 구하기
        float minAngle = -(numberOfProjectilePerShot / 2f) * projectilesAngleSpace +
                         0.5f * projectilesAngleSpace;
        
        for (int i = 0; i < numberOfProjectilePerShot; i++) 
        {
            float angle = minAngle + i * projectilesAngleSpace;
            CreateBullet(characterData,angle);
        }
    }

    private void CreateBullet(CharacterData characterData,float angle)
    {
        PoolObject bullet = GameManager.Instance.Pool.SpawnFromPool("Bullet");
        bullet.transform.position = weaponPivot.position;
        bullet.transform.Rotate(0,0,angle);
        bullet.BulletInit(characterData.AtkDamage,characterData.BulletSpeed, targetLayer);
    }
}