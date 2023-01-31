using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleLevelPart : MonoBehaviour
{
    public PuzzleType puzzleType = PuzzleType.NONE;
    private Image puzzleImage = default;
    private PlayLevel playLevel = default;

    // Start is called before the first frame update
    void Start()
    {        
        //ºò Æ®¶óÀÌ¾Þ±Û ¼±¾ð
        puzzleImage = gameObject.FindChildObj("PuzzleLv_Image").GetComponentMust<Image>();

       

        switch (puzzleImage.sprite.name) 
        {
            case "Puzzle_BigTriangle1":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE; 
                break;
            case "Puzzle_BigTriangle2":
                puzzleType = PuzzleType.PUZZLE_BIG_TRIANGLE;
                break;
            case "Puzzle_MiddleTriangle":
                puzzleType = PuzzleType.PUZZLE_MIDDLE_TRIANGLE;
                break;
            case "Puzzle_Parallelogram":
                puzzleType = PuzzleType.PUZZLE_PARALLELOGRAM;
                break;
            case "Puzzle_SmallTriangle1":
                puzzleType = PuzzleType.PUZZLE_SMALL_TRIANGLE;
                break;
            case "Puzzle_SmallTriangle2":
                puzzleType = PuzzleType.PUZZLE_SMALL_TRIANGLE;
                break;
            case "Puzzle_Square":
                puzzleType = PuzzleType.PUZZLE_SQUARE;
                break;

            default:
                puzzleType = PuzzleType.NONE;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
