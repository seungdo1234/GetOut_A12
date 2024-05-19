using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class TopDownShooting : MonoBehaviour
{
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private LayerMask targetLayer;
    
    protected void Shooting(CharacterData characterData, string tag)
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
            CreateBullet(characterData, angle, tag);
        }
    }

    // Conflict 방지를 위한 추가 제작 [매개변수만 수정]
    protected void Shooting(CharacterStat characterStat, string tag)
    {
        // 몇 도 만큼 각도를 띄울건지
        float projectilesAngleSpace = characterStat.BulletAngle;
        // 한 번에 몇발 나갈 건지
        int numberOfProjectilePerShot = characterStat.BulletNum;

        // 최소 각 구하기
        float minAngle = -(numberOfProjectilePerShot / 2f) * projectilesAngleSpace +
                         0.5f * projectilesAngleSpace;

        for (int i = 0; i < numberOfProjectilePerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            CreateBullet(characterStat, angle, tag);
        }
    }

    private void CreateBullet(CharacterData characterData,float angle, string tag)
    {
        PoolObject bullet = GameManager.Instance.Pool.SpawnFromPool(tag);
        bullet.transform.position = weaponPivot.position;
        bullet.transform.Rotate(0,0,angle);
        bullet.BulletInit(characterData.AtkDamage,characterData.BulletSpeed, targetLayer);
    }

    // Conflict 방지를 위한 추가 제작 [매개변수만 수정]
    private void CreateBullet(CharacterStat characterStat, float angle, string tag)
    {
        PoolObject bullet = GameManager.Instance.Pool.SpawnFromPool(tag);
        bullet.transform.position = weaponPivot.position;
        bullet.transform.Rotate(0, 0, angle);
        bullet.BulletInit(characterStat.AtkDamage, characterStat.BulletSpeed, targetLayer);
    }
}
