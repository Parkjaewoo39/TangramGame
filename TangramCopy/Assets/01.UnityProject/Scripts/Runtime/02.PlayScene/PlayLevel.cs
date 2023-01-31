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

        }   //loop: ���� �������� ���� ������ ��� ĳ���ϴ� ����

    }

    // Update is called once per frame
    void Update()
    {

    }

    //! ���� Ÿ���� �޾Ƽ� �ش� Ÿ�԰� ���� Ÿ���� ������ �����ϴ� �Լ�
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

        }   //loop: ���� Ÿ���� ������ ã���ִ� ����
        
        return sameTypes;
    }   //GetSameTypePuzzle()

    //! ���� ����� ������ ã���ִ� �Լ�
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
                
            }   // if: ���� ����� ������ ĳ���Ѵ�. 
            index++;
            
        }   //loop: 
        GFunc.Log($"{LEVEL_PUZZLE_DISTANCE_LIMIT - minDistance}");
        if (LEVEL_PUZZLE_DISTANCE_LIMIT < minDistance) 
        {
            result = default;
        }   //if �ʹ� �ָ� �ִ� ������ �����Ѵ�.
        
        return result;
    }   //GetCloseSameTypePuzzle
}
