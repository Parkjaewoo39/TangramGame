using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{
    public static void QuitThisGame() 
    {
        //게임 종료함수
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }   //QuitThisGame()
    public static void Jaewoo123Func(this GameObject obj_) 
    {
        Debug.Log("이것은 내가 만든 함수가 분명하다");
    }

    //!다른 씬 로드하는 함수
    public static void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene("PlayScence");
    }   //LoadScene


}
