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
    //enum타입으로 지정하면
    //영문타입을 지정하면 숫자랑 1:1 맵핑해줌
    //-1을 해주면 그 타입은 0이 됨.
    //-1로 시작하면 정산적이지 않음
    //위에서 아래로 숫자 타입이 늘어남.
    //none으로 0부터 시작할지 1부터 시작할지 초기화 시작점을 만들수 있다?
    NONE = -1,
    PUZZLE_BIG_TRIANGLE,
    PUZZLE_SQUARE,
    PUZZLE_MIDDLE_TRIANGLE,
    //Puzzle_Parallelogram
    PUZZLE_PARALLELOGRAM,
    PUZZLE_SMALL_TRIANGLE,
}   //PuzzleType()
