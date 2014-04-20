using UnityEngine;
using System.Collections;

public class DragDrop : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;

	private ClothesDetails clothesDetails;

	private SpaceDetails closetDetails;

	public bool inCloset = false;
	public bool fit = false;
	public bool moved = false;
	// Use this for initialization
	void Start () {
		closetDetails = GameObject.Find("Closet_Space").GetComponent<SpaceDetails>();
		clothesDetails = gameObject.GetComponent<ClothesDetails>();
		gameObject.rigidbody2D.gravityScale = 0;
		gameObject.transform.localScale = new Vector3(.2f, .2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		gameObject.rigidbody2D.gravityScale = 0;
		gameObject.transform.localScale = new Vector3(.75f, .75f, 1f);
		//gameObject.collider2D.enabled = false;
	}
	
	void OnMouseDrag(){
		if(gameObject.transform.position.x != clothesDetails.lastPosition.x){// || gameObject.transform.position.y != clothesDetails.lastPosition.y){
			moved = true;
		}

		else{
			moved = false;
		}

		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

		if(gameObject.collider2D.enabled == true && moved){
			gameObject.collider2D.enabled = false;
		}

		gameObject.transform.position = curPosition;
		

	}

	void OnMouseUp(){

		if(moved){
			DropClothes();
		}

		if(inCloset == false || fit == false){
			gameObject.transform.position = gameObject.GetComponent<ClothesDetails>().originalPosition;
			gameObject.rigidbody2D.gravityScale = 0;
			switch(clothesDetails.spaceSide){
				case 1:{
					closetDetails.space1_count += clothesDetails.clothesHeight;
					break;
				} 
				case 2:{
					closetDetails.space2_count += clothesDetails.clothesHeight;
					break;
				}
				case 3:{
					closetDetails.space3_count += clothesDetails.clothesHeight;
					break;
				}
				case 4:{
					closetDetails.space4_count += clothesDetails.clothesHeight;
					break;
				}
			}
			clothesDetails.spaceSide = 0;
			gameObject.transform.localScale = new Vector3(.2f, .2f, 1f);
		}
		else{
			gameObject.rigidbody2D.gravityScale = 2;
			clothesDetails.lastPosition = gameObject.transform.position;
		}

		gameObject.collider2D.enabled = true;

	}

	void DropClothes(){
		Vector3 currentPosition = gameObject.transform.position;
		Vector3 clothesSize = gameObject.renderer.bounds.size;

		if(currentPosition.x-clothesSize.x/2f > closetDetails.space1-(clothesSize.x/3f) && currentPosition.x+clothesSize.x/2f < closetDetails.edge+(clothesSize.x/3f) && currentPosition.y-clothesSize.y/2f > closetDetails.bottom-(clothesSize.y/3f) && currentPosition.y+clothesSize.y/2f < closetDetails.top+(clothesSize.y/3f)){
			inCloset = true;
			SnapToFit(currentPosition, clothesSize);
		}
		else{
			inCloset = false;
		}
	}

	void SnapToFit(Vector3 currentPosition, Vector3 clothesSize){
		if(currentPosition.x >= closetDetails.space1 && currentPosition.x < closetDetails.space2){
			if(closetDetails.space1_count > 0){
				if(closetDetails.space1_count >= clothesDetails.clothesHeight){
					gameObject.transform.position = new Vector3(closetDetails.space1+clothesSize.x/2f+.046f, closetDetails.top, currentPosition.y);

					switch(clothesDetails.spaceSide){
					case 1:{
						closetDetails.space1_count += clothesDetails.clothesHeight;
						break;
					}
					case 2:{
						closetDetails.space2_count += clothesDetails.clothesHeight;
						break;
					}
					case 3:{
						closetDetails.space3_count += clothesDetails.clothesHeight;
						break;
					}
					case 4:{
						closetDetails.space4_count += clothesDetails.clothesHeight;
						break;
					}
					}

					clothesDetails.spaceSide = 1;

					closetDetails.space1_count -= clothesDetails.clothesHeight;
					fit = true;
				}
				else{
					fit = false;
				}
			}
		}
		else if(currentPosition.x >= closetDetails.space2 && currentPosition.x < closetDetails.space3){
			if(closetDetails.space2_count > 0){
				if(closetDetails.space2_count >= clothesDetails.clothesHeight){
					gameObject.transform.position = new Vector3(closetDetails.space2+clothesSize.x/2f+.046f, closetDetails.top, currentPosition.y);

					switch(clothesDetails.spaceSide){
					case 1:{
						closetDetails.space1_count += clothesDetails.clothesHeight;
						break;
					} 
					case 2:{
						closetDetails.space2_count += clothesDetails.clothesHeight;
						break;
					}
					case 3:{
						closetDetails.space3_count += clothesDetails.clothesHeight;
						break;
					}
					case 4:{
						closetDetails.space4_count += clothesDetails.clothesHeight;
						break;
					}
					}

					clothesDetails.spaceSide = 2;
					
					closetDetails.space2_count -= clothesDetails.clothesHeight;

					fit = true;
				}
				else{
					fit = false;
				}
			}
		}
		else if(currentPosition.x >= closetDetails.space3 && currentPosition.x < closetDetails.space4){
			if(closetDetails.space3_count > 0){
				if(closetDetails.space3_count >= clothesDetails.clothesHeight){
					gameObject.transform.position = new Vector3(closetDetails.space3+clothesSize.x/2f+.046f, closetDetails.top, currentPosition.y);
				
					switch(clothesDetails.spaceSide){
					case 1:{
						closetDetails.space1_count += clothesDetails.clothesHeight;
						break;
					} 
					case 2:{
						closetDetails.space2_count += clothesDetails.clothesHeight;
						break;
					}
					case 3:{
						closetDetails.space3_count += clothesDetails.clothesHeight;
						break;
					}
					case 4:{
						closetDetails.space4_count += clothesDetails.clothesHeight;
						break;
					}
					}

					clothesDetails.spaceSide = 3;
					
					closetDetails.space3_count -= clothesDetails.clothesHeight;

					fit = true;
				}
				else{
					fit = false;
				}
			}
		}
		else if(currentPosition.x >= closetDetails.space4 && currentPosition.x < closetDetails.edge){
			if(closetDetails.space4_count > 0){
				if(closetDetails.space4_count >= clothesDetails.clothesHeight){
					gameObject.transform.position = new Vector3(closetDetails.space4+clothesSize.x/2f+.046f, closetDetails.top, currentPosition.y);
				
					switch(clothesDetails.spaceSide){
					case 1:{
						closetDetails.space1_count += clothesDetails.clothesHeight;
						break;
					} 
					case 2:{
						closetDetails.space2_count += clothesDetails.clothesHeight;
						break;
					}
					case 3:{
						closetDetails.space3_count += clothesDetails.clothesHeight;
						break;
					}
					case 4:{
						closetDetails.space4_count += clothesDetails.clothesHeight;
						break;
					}
					}

					clothesDetails.spaceSide = 4;
					
					closetDetails.space4_count -= clothesDetails.clothesHeight;

					fit = true;
				}
				else{
					fit = false;
				}
			}
		}
	}
}
