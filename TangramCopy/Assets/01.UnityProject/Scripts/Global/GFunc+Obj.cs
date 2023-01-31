using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{    
    public static GameObject FindChildObj(
        this GameObject targetObj_, string objName_) 
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;
        for (int i = 0; i < targetObj_.transform.childCount; i++) 
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else 
            {
                searchResult = FindChildObj(searchTarget, objName_);
            }
            
            if (searchResult == null ||searchResult == default) 
            { /* Do nothing*/ }
            else { return searchResult; }
            
        }
        return searchResult;    
    }//FindChildObj()

    // {LEGACY

    ////! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    //private static GameObject GetChildObj(
    //    this GameObject targetObj_,string objName_) 

    //{
    //    GameObject searchResult = default;
    //    for (int i = 0; i < targetObj_.transform.childCount; i++) 
    //    {

    //        if (targetObj_.transform.GetChild(i)
    //            .gameObject.name.Equals(objName_)) 
    //        {
    //            searchResult = targetObj_.transform.
    //                GetChild(i).gameObject;
    //            return searchResult;
    //        }   //if Ÿ�� ������Ʈ���� �̸��� ���� ������Ʈ�� ã�Ƽ� ����
    //        else { continue; }            
    //    }   //loop

    //        //�̸��� ���� ������Ʈ�� ã�� ���� ��� default ���� �����Ѵ�.
    //    return searchResult;
    //}   //GetChildObj()

    // }LEGACY

    //!���� ��Ʈ ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject GetRootObj(string objName_) 
    {
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();
       

        GameObject targetObj_ = default;
        foreach (GameObject rootObj in rootObjs_) 
        {
            if (rootObj.name.Equals(objName_))
            {
                targetObj_ = rootObj;
                return targetObj_;
            }
            else { continue; }
        }   //loop

        return targetObj_;
    }   //GetRootObj

    public static Vector2 GetRectSizeDelta(this GameObject obj_) 
    {
        return obj_.GetComponent<RectTransform>().sizeDelta;
    }

    public static RectTransform GetRect(this GameObject obj_) 
    {
        return obj_.GetComponent<RectTransform>();
    }   //GetRect()

    //! 오브젝트의 앵커 포지션을 연산하는 함수
    public static void AddAnchoredPos(this GameObject obj_,float x, float y) 
    {
        obj_.GetRect().anchoredPosition += new Vector2(x, y);
    }   //AddAnchoredPos()

    //! 오브젝트의 앵커 포지션을 연산하는 함수
    public static void AddAnchoredPos(this GameObject obj_, Vector2 position2D)
    {
        obj_.GetRect().anchoredPosition += position2D;
    }   //AddAnchoredPos()

   
    //! 
    public static Scene GetActiveScene() 
    {
        Scene activeScene_= SceneManager.GetActiveScene();
        return activeScene_;
    }   //GetActiveScene

    //! 오브젝트의 로컬 포지션을 변경하는 함수
    public static void SetLocalPos(this GameObject obj_, float x, float y, float z) 
    {
        obj_.transform.localPosition = new Vector3(x, y, z);
    }

    //! 오브젝트의 로컬 포지션을 연산하는 함수
    public static void AddLocalPos(this GameObject obj_, float x, float y, float z) 
    {
        obj_.transform.localPosition = obj_.transform.localPosition + new Vector3(x, y, z);
    }   //AddLocalPos()

    //! 트랜스폼을 사용해서 오브젝트를 움직이는 함수.
    public static void Translate(this Transform transform_, Vector2 moveVector) 
    {
        transform_.Translate(moveVector.x,moveVector.y, 0f);
    }   //Translate()

    //! 컴포넌트 가져오는 함수
    public static T GetComponentMust<T>(this GameObject obj) 
    {
        T component_ = obj.GetComponent<T>();
               
            //((Component)(component_ as Component)).IsValid();

        GFunc.Assert(component_.IsValid<T>() != false , 
            string.Format("{0}에서 {1}을(를) 찾을 수 없습니다.",
            obj.name,component_.GetType().Name));
        //GFunc.Assert(component_ != default);
        //<T> 무언가를 받겠다 어느 이름이라도 괜찮음. 현업은 한글자  T가 편해서T로 씀
       // GFunc.Log($"{component_.GetType().Name} is found");
        return component_;
    }

    //!새로운 오브젝트를 만들어서 컴포넌트를 리턴하는 함수
    public static T Create<T>(string objName) where T : Component
    {
        GameObject newObj = new GameObject(objName);
        return newObj.AddComponent<T>();
    }   //Create<T>


    #region
    //public static AudioSource GetAudioSourceMust(this GameObject obj)
    //{
    //    AudioSource component_ = obj.GetComponent<AudioSource>();


    //    GFunc.Assert(component_ != null || component_ != default,
    //        string.Format("{0}에서 {1}을(를) 찾을 수 없습니다.",
    //        obj.name, component_.GetType().Name));
    //    //GFunc.Assert(component_ != default);
    //    //<T> 무언가를 받겠다 어느 이름이라도 괜찮음. 현업은 한글자  T가 편해서T로 씀
    //    GFunc.Log($"{component_.GetType().Name} is found");
    //    return component_;
    //}
    #endregion
}
