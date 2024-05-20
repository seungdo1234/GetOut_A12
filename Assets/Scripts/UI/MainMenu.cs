using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //버튼 작동, "MainScene"으로 전환. File - Build Settings에서 이동 할 씬들을 등록해야 작동 함.
        SceneManager.LoadScene("MainScene");
        

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


