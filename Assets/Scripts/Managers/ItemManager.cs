using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    [SerializeField] [Range(7, 30)] private int itemRandomInt;

    [SerializeField] private GameObject AutoCannon; // 배열????에 넣고 반복문.
    [SerializeField] private GameObject Rockets;
    [SerializeField] private GameObject Zapper;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //매개 변수로 몬스터 위치 불러와야되나?
    public void DropInfo(GameObject monster)
    {
        int Randomint = Random.Range(0, itemRandomInt);

        if(Randomint < 0)
        {
            itemInstantiate(AutoCannon, monster, EWeaponType.AutoCannon);
        }
        else if (Randomint < 3)
        {
            itemInstantiate(Rockets, monster, EWeaponType.Rockets);
        }
        else if (Randomint < 6)
        {
            itemInstantiate(Zapper, monster, EWeaponType.Zapper);
        }
        else
        {
            Debug.Log("아무일도... 없었다...");
        }
    }

    private void itemInstantiate(GameObject items , GameObject monster, EWeaponType eWeaponType)
    {
        Item item = Instantiate(items, monster.transform.position, items.transform.rotation).GetComponent<Item>(); // 반복문 으로????
        item.ItmeInit(eWeaponType);
    }
}