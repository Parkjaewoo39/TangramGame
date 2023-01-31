using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler//, IPointerMoveHandler
{


    //float d = 10.0f;
    //public void OnDrag(PointerEventData evnetData) 
    //{
    //    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    transform.position = mousePosition;
    //}
    private PuzzleType puzzleType = PuzzleType.NONE;
    private Image puzzleImage = default;


    private bool isClicked = false; //Ȯ�ο� boolŸ�� ����
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    private PlayLevel playLevel = default;
    //List<PuzzleLevelPart> puzzleLevelParts
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;   //start���� �ѹ��� �ʱ�ȭ

        objRect = gameObject.GetRect();

        puzzleInitZone = transform.parent.gameObject.
            GetComponentMust<PuzzleInitZone>();

        playLevel = GameManager.Instance.gameObjs[GData.OBJ_NAME_CURRENT_LEVEL].
            GetComponentMust<PlayLevel>();

        puzzleImage = gameObject.FindChildObj("PuzzleLv_Image").GetComponentMust<Image>();
        

        //���� �̹��� �̸��� ���� ������ Ÿ���� ��������.
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

    //! ���콺 ��ư�� ������ �� �����ϴ� �Լ�
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

        //gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f); 
        // GFunc.Log($"{gameObject.name}�� �����ߴ�");
    }   //OnPointerDown()

    //! ���콺 ��ư�� ���� ���� �� �����ϴ� �Լ�
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        // GFunc.Log($"{gameObject.name}�� ���� �����ߴ�");
        //���⼭ ������ ������ �ִ� ���� ����Ʈ�� ��ȸ�ؼ� ���� ����� ������ ã�ƿ´�.
        PuzzleLevelPart closeLevelPuzzle = playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);
        

        if (closeLevelPuzzle == null || closeLevelPuzzle == default)
        {
            return;
        }
        GFunc.Log($"{closeLevelPuzzle.name}�� ���� �����̿� �ֽ��ϴ�.");
        transform.position = closeLevelPuzzle.transform.position;
    }   //OnPointerUp()

    //! ���콺�� �巡�� ���� �� �����ϴ� �Լ�

    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true) 
        {
            //
            gameObject.AddAnchoredPos(eventData.delta/ puzzleInitZone.parentCanvas.scaleFactor);
        }
    }
    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    if (isClicked == true)
    //    {

    //        gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f);
    //       // GFunc.Log($"���콺�� �������� ������ Ȯ�� : {eventData.position.x},{eventData.position.y}");
    //    }       //if : ���� ������Ʈ�� ������ ���
    //}   //OnPointerMoveHandler()
}
