using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    //�Ű� ������ ���� ��ġ �ҷ��;ߵǳ�?
    public void DropInfo(GameObject monster) // TODO::���� �ı� �� �Լ� ȣ��
    {
        int Randomint = Random.Range(0, 21);
        

        if(Randomint < 10)
        {
            Debug.Log("����Ե� �ƹ��ϵ� ������");
        }
        else if(Randomint < 13)
        {
            Item item = Instantiate(gameObject/*TODO:: ������*/, monster.transform.position, gameObject/*TODO:: ������*/.transform.rotation).GetComponent<Item>();
            item.ItmeInit(EWeaponType.AutoCannon);
        }
        else if (Randomint < 16)
        {
            Item item = Instantiate(gameObject/*TODO:: ������*/, monster.transform.position, gameObject/*TODO:: ������*/.transform.rotation).GetComponent<Item>();
            item.ItmeInit(EWeaponType.Rockets);
        }
        else if (Randomint < 19)
        {
            Item item = Instantiate(gameObject/*TODO:: ������*/, monster.transform.position, gameObject/*TODO:: ������*/.transform.rotation).GetComponent<Item>();
            item.ItmeInit(EWeaponType.Zapper);
        }
        else
        {
            Debug.Log("�׷��� �װ��� ������ �Ͼ���ϴ� ����");
        }
    }
}
