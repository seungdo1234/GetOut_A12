using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class Item : MonoBehaviour
{
    EWeaponType itemType;
    [SerializeField] private float dropSpeed = 2.0f;
    Rigidbody2D rd;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.velocity = Vector2.down * dropSpeed;
    }

    public void ItemInit(EWeaponType type)
    {
        itemType = type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ItemManager.Instance.SpecialWeaponHandler.EquipSpecialWeapon(itemType);
            Destroy(this.gameObject);
        }
    }
}