using UnityEngine;
using System.Collections;

public class ClothesDetails : MonoBehaviour {

	public Vector3 originalPosition;
	public Vector3 lastPosition;

	public string color;
	public int clothesHeight;
	public int spaceSide = 0;
	// Use this for initialization
	void Start () {
		//blue();
		originalPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void blue(){
		if(gameObject.name.Equals("Blue_1")){
			color = "blue";
			clothesHeight = 1;
		}
		else if(gameObject.name.Equals("Blue_2")){
			color = "blue";
			clothesHeight = 2;
		}
		else if(gameObject.name.Equals("Blue_3")){
			color = "blue";
			clothesHeight = 3;
		}
		else if(gameObject.name.Equals("Blue_4")){
			color = "blue";
			clothesHeight = 4;
		}
		else if(gameObject.name.Equals("Blue_5")){
			color = "blue";
			clothesHeight = 5;
		}
		else if(gameObject.name.Equals("Blue_6")){
			color = "blue";
			clothesHeight = 6;
		}
		else if(gameObject.name.Equals("Blue_7")){
			color = "blue";
			clothesHeight = 7;
		}
		else if(gameObject.name.Equals("Blue_8")){
			color = "blue";
			clothesHeight = 8;
		}
	}

	void blue(){
		if(gameObject.name.Equals("_1")){
			color = "";
			clothesHeight = 1;
		}
		else if(gameObject.name.Equals("_2")){
			color = "";
			clothesHeight = 2;
		}
		else if(gameObject.name.Equals("_3")){
			color = "";
			clothesHeight = 3;
		}
		else if(gameObject.name.Equals("_4")){
			color = "";
			clothesHeight = 4;
		}
		else if(gameObject.name.Equals("_5")){
			color = "";
			clothesHeight = 5;
		}
		else if(gameObject.name.Equals("_6")){
			color = "";
			clothesHeight = 6;
		}
		else if(gameObject.name.Equals("_7")){
			color = "";
			clothesHeight = 7;
		}
		else if(gameObject.name.Equals("_8")){
			color = "";
			clothesHeight = 8;
		}
	}*/
}
