using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //��ư �۵�, "MainScene"���� ��ȯ. File - Build Settings���� �̵� �� ������ ����ؾ� �۵� ��.
        SceneManager.LoadScene("MainScene");
        

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


