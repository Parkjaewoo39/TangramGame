using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler//, IPointerMoveHandler
{

    
    //float d = 10.0f;
    //public void OnDrag(PointerEventData evnetData) 
    //{
    //    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    transform.position = mousePosition;
    //}
    
    private bool isClicked = false; //확인용 bool타입 선언
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;   //start에서 한번더 초기화
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.gameObject.GetComponentMust<PuzzleInitZone>();
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

    }

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
