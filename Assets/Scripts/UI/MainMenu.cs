using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    // 메인메뉴씬 구성 후, 메인씬과 연결 하기.




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    // Start버튼 구현 중
    public void OnCllickNewGame()
    {
        //버튼으로 두어야 하는지 확인 필요하므로, 4주차 프로젝트 해설 참고하여 구현하기.
        Debug.Log("새 게임");
    }


    // Quit버튼 구현 완료. Quit 버튼 누르면 게임종료.
    public void OnclickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}


