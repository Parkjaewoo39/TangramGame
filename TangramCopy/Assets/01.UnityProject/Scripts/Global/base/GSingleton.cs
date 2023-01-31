using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSingleton<T> : GComponenet where T : GSingleton<T>
{
    // ��_�� private�ؼ� ĸ��ȭ �ؼ� �Ⱥ����شٶ�� �ǹ�
    private static T _instance = default;

    public static T Instance
    {
        get
        {
            if (GSingleton<T>._instance == default || _instance == default)
            {
                GSingleton<T>._instance = 
                    GFunc.Create<T>(typeof(T).ToString());//???????

                DontDestroyOnLoad(_instance.gameObject);
            }   //if �ν��Ͻ��� ��������� ���� �ν��Ͻ�ȭ �Ѵ�.

            //���⼭ ���ʹ� �ν��Ͻ��� ���� ������� ��������?
            return _instance;
        }
    }
    public override void Awake()
    {
        base.Awake();
    }   //Awake()

    public void Create()
    {
        this.Init();
        
    }   //Create() �ν��Ͻ�ȭ�� ������ ���ְ�?

    protected virtual void Init()
    {
        /*Do something*/
    }


}
