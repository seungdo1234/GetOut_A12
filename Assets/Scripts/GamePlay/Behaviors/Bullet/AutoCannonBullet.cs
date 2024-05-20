using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonBullet : PoolObject
{
    [SerializeField] private LayerMask targetLayer;
    private Rigidbody2D rigid;
    private float damage;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void AutoCannonInit(float damage, float cannonSpeed)
    {
        rigid.velocity = cannonSpeed * transform.up;
        this.damage = damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsLayerMatched (targetLayer.value,other.gameObject.layer))
        {
            gameObject.SetActive(false);
        }
    }
    
    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
