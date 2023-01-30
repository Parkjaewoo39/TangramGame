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
        }   //if: ������ �ؽ�Ʈ�޽� ������Ʈ�� ���� ���

        //������ �ؽ�Ʈ�޽� ������Ʈ�� �����ϴ°��
        tmpTxt.text = text_;
    }   //SetTextMeshPro()
}
