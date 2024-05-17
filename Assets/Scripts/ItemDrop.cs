using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    //매개 변수로 몬스터 위치 불러와야되나?
    public void DropInfo(GameObject monster) // TODO::몬스터 파괴 시 함수 호출
    {
        int Randomint = Random.Range(0, 21);
        

        if(Randomint < 10)
        {
            Debug.Log("놀랍게도 아무일도 없었다");
        }
        else if(Randomint < 13)
        {
            Item item = Instantiate(gameObject/*TODO:: 아이템*/, monster.transform.position, gameObject/*TODO:: 아이템*/.transform.rotation).GetComponent<Item>();
            item.ItmeInit(EWeaponType.AutoCannon);
        }
        else if (Randomint < 16)
        {
            Item item = Instantiate(gameObject/*TODO:: 아이템*/, monster.transform.position, gameObject/*TODO:: 아이템*/.transform.rotation).GetComponent<Item>();
            item.ItmeInit(EWeaponType.Rockets);
        }
        else if (Randomint < 19)
        {
            Item item = Instantiate(gameObject/*TODO:: 아이템*/, monster.transform.position, gameObject/*TODO:: 아이템*/.transform.rotation).GetComponent<Item>();
            item.ItmeInit(EWeaponType.Zapper);
        }
        else
        {
            Debug.Log("그런대 그것이 실제로 일어났습니다 ㅋㅋ");
        }
    }
}
