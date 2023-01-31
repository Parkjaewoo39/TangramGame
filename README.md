# TangramGame    
refer Copy mobile game    
2023-01-30 / v0.0.1 / Init Tangram game project      
2023-01-30 / v0.0.2 / Init Add Font       
2023-01-30 / v0.1.0 / Setup Tangram Game Project            
2023-01-30 / v0.2.0 / Add Btn Title     
issue.     
-Summary : unity 2D 프로젝트에서 오브젝트 드래그를 구현할때 IPointerMoveHandler 사용해서 구현하는 중 이슈 발생     
-Detail :     
	1.IPointerMoverHandler 에서 구현하는 OnPointMove메서드는 IDargHander에서구현하는      
		OnDrag 메서드보다 호출 속도가 느려서 오브젝트 드래그 도중에 오브젝트를 놓친다.     
		이후에는 OnDrag 메서드를 사용해서 구현하는 것이 더 나은 방식인 것으로 추정된다.     
	2. PointerEventData에서 가지고 오는 마우스 position 을 기준으로 오브젝트 위치를 계산할 때      
		오브젝트 자신의 피벗(Center) 위치 만큼의 오차가 발생했다. 오브젝트의 Local포지션을    
		마우스 포인터를 기준으로 절대좌표로 재설정 했을 때 피벗 이슈가 발생하는 것을 확인했다.    
		이후에는 오브젝트를 움직일 때 절대좌표가 아닌 상대적인 움직임(Delta)을 더해서 연산하는 방식이     
		오차가 적을 것으로 추정된다.     
	3. 캔버스 하위에 위치한 오브젝트를 움직일 때 Local position을 연산해서 움직이면 Anchor의 Pivot과 Canvas의     
		ScaleFactor 값 만큼의 오차가 발생하게 된다. 이후에는 Local position이 아닌, Anchored position과    
		ScaleFactor 값을 고려해서 연산하는 것이 오차가 적을 것으로 추정된다.     

2023-01-31 / v0.2.1 / Add Drag
  


