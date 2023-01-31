using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = default;
    public List<PuzzleLevelPart> puzzleLevelParts = default;


    private const float LEVEL_PUZZLE_DISTANCE_LIMIT = 1f;
    public void Awake()
    {
        //GameManager.Instance.Create();
        GameManager.Instance.gameObjs.Add(gameObject.name, gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzleLevelParts = new List<PuzzleLevelPart>();
        for (int i = 0; i < transform.childCount; i++)
        {
            puzzleLevelParts.Add(transform.GetChild(i).
                gameObject.GetComponentMust<PuzzleLevelPart>());

        }   //loop: 레벨 하위에서 퍼즐 파츠를 모두 캐싱하는 루프

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! 퍼즐 타입을 받아서 해당 타입과 같은 타입의 퍼즐을 리턴하는 함수
    private List<PuzzleLevelPart> GetSameTypePuzzle(PuzzleType puzzleType) 
    {
        List<PuzzleLevelPart> sameTypes = new List<PuzzleLevelPart>();
        foreach (var puzzleLvPart in puzzleLevelParts) 
        {
            if (puzzleLvPart.puzzleType.Equals(puzzleType))
            {
                
                sameTypes.Add(puzzleLvPart);
            }
            else { continue; }

        }   //loop: 같은 타입의 퍼즐을 찾아주는 루프
        
        return sameTypes;
    }   //GetSameTypePuzzle()

    //! 가장 가까운 퍼즐을 찾아주는 함수
    public PuzzleLevelPart GetCloseSameTypePuzzle(PuzzleType puzzleType, Vector3 puzzleWorldPos) 
    {
        List<PuzzleLevelPart> sameTypes = GetSameTypePuzzle(puzzleType);
        
        float minDistance = float.MaxValue;
        float distance = float.MaxValue;
        int index = 0;
        PuzzleLevelPart result = default;
        foreach (var puzzleLevelPart in sameTypes) 
        {
            distance = Mathf.Abs(
                (puzzleLevelPart.transform.position - 
                puzzleWorldPos).magnitude);
            

            if (distance <= minDistance) 
            {
                minDistance = distance;
                result = puzzleLevelPart;
                
            }   // if: 가장 가까운 퍼즐을 캐싱한다. 
            index++;
            
        }   //loop: 
        GFunc.Log($"{LEVEL_PUZZLE_DISTANCE_LIMIT - minDistance}");
        if (LEVEL_PUZZLE_DISTANCE_LIMIT < minDistance) 
        {
            result = default;
        }   //if 너무 멀리 있는 퍼즐은 생략한다.
        
        return result;
    }   //GetCloseSameTypePuzzle
}
