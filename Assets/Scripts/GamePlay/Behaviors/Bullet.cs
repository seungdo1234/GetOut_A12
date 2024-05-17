using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : PoolObject
{
    private Rigidbody2D rigid;
    [SerializeField]private LayerMask targetLayer;
    private float damage;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public override void BulletInit( float damage,float bulletSpeed ,LayerMask targetLayer)
    {
        rigid.velocity = transform.up * bulletSpeed;
        this.targetLayer = targetLayer;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched(other.gameObject.layer ,targetLayer.value))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            DisableBullet();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BackGround"))
        {
            DisableBullet();
        }
    }

    private void DisableBullet()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
        gameObject.SetActive(false);
    }
    
    // 레이어가 일치하는지 확인하는 메소드입니다.
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}