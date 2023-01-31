using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSingleton<T> : GComponenet where T : GSingleton<T>
{
    // 앞_는 private해서 캡슐화 해서 안보여준다라는 의미
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
            }   //if 인스턴스가 비어있을때 새로 인스턴스화 한다.

            //여기서 부터는 인스턴스가 절대 비어있지 않을려나?
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
        
    }   //Create() 인스턴스화를 무조건 해주게?

    protected virtual void Init()
    {
        /*Do something*/
    }


}
