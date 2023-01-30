using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static partial class GFunc
{
    public static void SetTmpText(this GameObject obj_, string text_)
    {
        Text tmpTxt = obj_.GetComponent<Text>();
        if (tmpTxt == null || tmpTxt == default(Text)) 
        {
            return;
        }   //if: 가져올 텍스트메쉬 컴포넌트가 없는 경우

        //가져올 텍스트메쉬 컴포넌트가 존재하는경우
        tmpTxt.text = text_;
    }   //SetTextMeshPro()
}
