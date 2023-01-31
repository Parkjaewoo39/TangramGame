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


    private bool isClicked = false; //확인용 bool타입 선언
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    private PlayLevel playLevel = default;
    //List<PuzzleLevelPart> puzzleLevelParts
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;   //start에서 한번더 초기화

        objRect = gameObject.GetRect();

        puzzleInitZone = transform.parent.gameObject.
            GetComponentMust<PuzzleInitZone>();

        playLevel = GameManager.Instance.gameObjs[GData.OBJ_NAME_CURRENT_LEVEL].
            GetComponentMust<PlayLevel>();

        puzzleImage = gameObject.FindChildObj("PuzzleLv_Image").GetComponentMust<Image>();
        

        //퍼즐 이미지 이름에 따라서 퍼즐의 타입이 정해진다.
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

    //! 마우스 버튼을 눌렀을 때 동작하는 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

        //gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f); 
        // GFunc.Log($"{gameObject.name}을 선택했다");
    }   //OnPointerDown()

    //! 마우스 버튼을 손을 땠을 때 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        // GFunc.Log($"{gameObject.name}을 선택 해제했다");
        //여기서 레벨이 가지고 있는 퍼즐 리스트를 순회해서 가장 가까운 퍼즐을 찾아온다.
        PuzzleLevelPart closeLevelPuzzle = playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);
        

        if (closeLevelPuzzle == null || closeLevelPuzzle == default)
        {
            return;
        }
        GFunc.Log($"{closeLevelPuzzle.name}이 가장 가까이에 있습니다.");
        transform.position = closeLevelPuzzle.transform.position;
    }   //OnPointerUp()

    //! 마우스를 드래그 중일 때 동작하는 함수

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
    //       // GFunc.Log($"마우스의 포지션을 눈으로 확인 : {eventData.position.x},{eventData.position.y}");
    //    }       //if : 현재 오브젝트를 선택한 경우
    //}   //OnPointerMoveHandler()
}
