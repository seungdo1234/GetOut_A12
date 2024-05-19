using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private LayerMask targetLayer;
    
    protected void Shooting(FlightStat flightStat, string tag)
    {
        // 몇 도 만큼 각도를 띄울건지
        float projectilesAngleSpace = flightStat.BulletAngle;
        // 한 번에 몇발 나갈 건지
        int numberOfProjectilePerShot = flightStat.BulletNum;

        // 최소 각 구하기
        float minAngle = -(numberOfProjectilePerShot / 2f) * projectilesAngleSpace +
                         0.5f * projectilesAngleSpace;

        for (int i = 0; i < numberOfProjectilePerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            CreateBullet(flightStat, angle, tag);
        }
    }

    private void CreateBullet(FlightStat flightStat, float angle, string tag)
    {
        PoolObject bullet = GameManager.Instance.Pool.SpawnFromPool(tag);
        bullet.transform.position = weaponPivot.position;
        bullet.transform.Rotate(0, 0, angle);
        bullet.BulletInit(flightStat.AtkDamage, flightStat.BulletSpeed, flightStat.BulletAnimator, targetLayer);
    }
}
