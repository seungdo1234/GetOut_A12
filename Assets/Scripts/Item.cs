using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item : MonoBehaviour
{
    EItemType itemType;
    [SerializeField] private float dropSpeed = 1.0f;
    Rigidbody2D rd;


    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.velocity = Vector2.down * dropSpeed;
    }

    public void ItmeInit(EWeaponType type)
    {
        itemType = type;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            switch (itemType)
            {
            case EWeaponType.AutoCannon:
                //TODO::해당 아이템 효과
                break;
            case EWeaponType.Rockets:
                //TODO::해당 아이템 효과
                break;
            case EWeaponType.Zapper:
                //TODO::해당 아이템 효과
                break;
            }
        }
    }
}
