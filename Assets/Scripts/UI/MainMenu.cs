using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    // ���θ޴��� ���� ��, ���ξ��� ���� �ϱ�.




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    // Start��ư ���� ��
    public void OnCllickNewGame()
    {
        //��ư���� �ξ�� �ϴ��� Ȯ�� �ʿ��ϹǷ�, 4���� ������Ʈ �ؼ� �����Ͽ� �����ϱ�.
        Debug.Log("�� ����");
    }


    // Quit��ư ���� �Ϸ�. Quit ��ư ������ ��������.
    public void OnclickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}


