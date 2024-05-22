using System.Collections;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private LayerMask targetLayer;
    protected FlightStatHandler flightStat;
    protected Rigidbody2D rigid;
    protected virtual void Awake()
    {
        flightStat = GetComponent<FlightStatHandler>();
        rigid = GetComponent<Rigidbody2D>();
    }

    protected void Shooting(FlightStat flightStat)
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
            SpawnBullet(flightStat, angle);
        }
    }

    protected void Shooting(FlightStat flightStat, Transform position)
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
            SpawnBullet(flightStat, angle, position);
        }
    }

    protected void Shooting(FlightStat flightStat, float angle)
    {
        // 정해진 각도로 바로 발사
        SpawnBullet(flightStat, angle);
    }

    protected void Bombing(FlightStat flightStat, float bombSpeed, float explodeDelay)
    {
        Bomb bomb = GameManager.Instance.Pool.SpawnFromPool(EPoolObjectType.Bomb).ReturnMyConponent<Bomb>();
        if (bomb != null)
        {
            bomb.transform.position = weaponPivot.position;
            bomb.DropBomb(bombSpeed);

            StartCoroutine(DelayShooting(explodeDelay, flightStat, bomb.transform));
                
        }
    }

    IEnumerator DelayShooting(float explodeDelay, FlightStat flightStat, Transform bomb)
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(explodeDelay);
        yield return wait;
        Shooting(flightStat, bomb.transform);
        bomb.gameObject.SetActive(false);
    }

    private void SpawnBullet(FlightStat flightStat, float angle)
    {
        Bullet bullet = GameManager.Instance.Pool.SpawnFromPool(EPoolObjectType.Bullet).ReturnMyConponent<Bullet>();
        if (bullet != null)
        {
            bullet.transform.position = weaponPivot.position; 
            bullet.transform.Rotate(0, 0, angle);
            bullet.BulletInit(flightStat.AtkDamage, flightStat.BulletSpeed, flightStat.BulletAnimator, targetLayer);   
        }
        else
        {
            Debug.Log("Bullet Null Error");
        }
    }

    private void SpawnBullet(FlightStat flightStat, float angle, Transform position)
    {
        Bullet bullet = GameManager.Instance.Pool.SpawnFromPool(EPoolObjectType.Bullet).ReturnMyConponent<Bullet>();
        if (bullet != null)
        {
            bullet.transform.position = position.position;
            bullet.transform.Rotate(0, 0, angle);
            bullet.BulletInit(flightStat.AtkDamage, flightStat.BulletSpeed, flightStat.BulletAnimator, targetLayer);
        }
        else
        {
            Debug.Log("Bullet Null Error");
        }
    }
}
