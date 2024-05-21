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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            switch (itemType)
            {
                case EWeaponType.AutoCannon:
                    Debug.Log("a획득");
                    //TODO::해당 아이템 효과
                    break;
                case EWeaponType.Rockets:
                    Debug.Log("r획득");
                    //TODO::해당 아이템 효과
                    break;
                case EWeaponType.Zapper:
                    Debug.Log("z획득");
                    //TODO::해당 아이템 효과
                    break;
            }
        }
        Destroy(this.gameObject);
    }
}
