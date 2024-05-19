using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : PoolObject
{
    private Rigidbody2D rigid;
    [SerializeField]private LayerMask targetLayer;
    private float damage;
    private Quaternion origRotation;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        origRotation = transform.rotation;
    }

    public override void BulletInit( float damage,float bulletSpeed ,LayerMask targetLayer)
    {
        rigid.velocity = transform.up * bulletSpeed;
        this.targetLayer = targetLayer;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched(targetLayer.value, other.gameObject.layer ))
        {
            /*
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            */
            HealthSystem healthSystem = other.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.ChangeHealth(-damage);
            }
            DisableBullet();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Camera"))
        {
            DisableBullet();
        }
    }

    private void DisableBullet()
    {
        transform.rotation = origRotation;
        gameObject.SetActive(false);
    }
    
    // 레이어가 일치하는지 확인하는 메소드입니다.
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}