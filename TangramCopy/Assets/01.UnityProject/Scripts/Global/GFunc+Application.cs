using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{
    public static void QuitThisGame() 
    {
        //���� �����Լ�
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }   //QuitThisGame()
    public static void Jaewoo123Func(this GameObject obj_) 
    {
        Debug.Log("�̰��� ���� ���� �Լ��� �и��ϴ�");
    }

    //!�ٸ� �� �ε��ϴ� �Լ�
    public static void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene("PlayScence");
    }   //LoadScene


}
