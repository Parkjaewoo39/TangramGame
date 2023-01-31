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
    
    private bool isClicked = false; //Ȯ�ο� boolŸ�� ����
    private RectTransform objRect = default;
    private PuzzleInitZone puzzleInitZone = default;
    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;   //start���� �ѹ��� �ʱ�ȭ
        objRect = gameObject.GetRect();
        puzzleInitZone = transform.parent.gameObject.GetComponentMust<PuzzleInitZone>();
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

    }

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
