using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GData
{
    public const string SCENE_NAME_TITLE = "01.TitleScene";

    public const string SCENE_NAME_PLAY = "02.PlayScene";

    public const string OBJ_NAME_CURRENT_LEVEL = "Level_1";

}

public enum PuzzleType 
{
    //enumŸ������ �����ϸ�
    //����Ÿ���� �����ϸ� ���ڶ� 1:1 ��������
    //-1�� ���ָ� �� Ÿ���� 0�� ��.
    //-1�� �����ϸ� ���������� ����
    //������ �Ʒ��� ���� Ÿ���� �þ.
    //none���� 0���� �������� 1���� �������� �ʱ�ȭ �������� ����� �ִ�?
    NONE = -1,
    PUZZLE_BIG_TRIANGLE,
    PUZZLE_SQUARE,
    PUZZLE_MIDDLE_TRIANGLE,
    //Puzzle_Parallelogram
    PUZZLE_PARALLELOGRAM,
    PUZZLE_SMALL_TRIANGLE,
}   //PuzzleType()
