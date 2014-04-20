using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject clothes1;
	public GameObject clothes2;
	public GameObject clothes3;
	public GameObject clothes4;
	public GameObject clothes5;
	public GameObject clothes6;
	public GameObject clothes7;
	public GameObject clothes8;

	public float score;
	public ArrayList clothes = new ArrayList();

	public bool timeUp = false;
	public bool finished = false;
	public bool paused = false;
	// Use this for initialization
	void Start () {
		generateClothes();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P) && timeUp == false && finished == false){
			if(paused == false){
				paused = true;
				Time.timeScale = 0;
			}
			else{
				paused = false;
				Time.timeScale = 1;
			}
		}

		if(GameObject.Find("TimeText").GetComponent<Timer>().timeUp){
			timeUp = true;
			Time.timeScale = 0;
		}

		if(clothesInCloset()){
			finished = true;
			Time.timeScale = 0;
		}
	}

	bool clothesInCloset(){
		for(int i = 0; i<clothes.Count; i++){
			if(((GameObject)clothes[i]).GetComponent<ClothesDetails>().spaceSide == 0){
				return false;
			}
		}
		return true;
	}

	void generateClothes(){
		string[] colors = new string[]{"Blue", "Yellow", "Red", "Gray", "Magenta", "Green"};

		GameObject table = GameObject.Find("Table");
		Vector3 tableSize = table.renderer.bounds.size;
		Vector3 tablePosition = table.transform.position;
		float tableSpace = tableSize.x/5f;
		float tableEdge = tablePosition.x - tableSize.x/2f;
		float tableTop = tablePosition.y + tableSize.y/2f + .2f;

		for(int i = 0; i<4 ; i++){
			int space = 8;
			for(int y = 0; space > 0 && y < 5; y++){
				int colorIndex = Random.Range(0, 6);
				int clothesHeight = Random.Range(1, 9);

				if(clothesHeight > space || y == 4){
					clothesHeight = space;
				}

				GameObject tempClothes;

				switch(clothesHeight){
				case 1:{
					tempClothes = (GameObject)Instantiate(clothes1);
					break;
				}
				case 2:{
					tempClothes = (GameObject)Instantiate(clothes2);
					break;
				}
				case 3:{
					tempClothes = (GameObject)Instantiate(clothes3);
					break;
				}
				case 4:{
					tempClothes = (GameObject)Instantiate(clothes4);
					break;
				}
				case 5:{
					tempClothes = (GameObject)Instantiate(clothes5);
					break;
				}
				case 6:{
					tempClothes = (GameObject)Instantiate(clothes6);
					break;
				}
				case 7:{
					tempClothes = (GameObject)Instantiate(clothes7);
					break;
				}
				case 8:{
					tempClothes = (GameObject)Instantiate(clothes8);
					break;
				}
				default:{
					tempClothes = (GameObject)Instantiate(clothes1);
					break;
				}
				}

				switch(colorIndex){
				case 0:{
					tempClothes.renderer.material.color = Color.blue;
					break;
				}
				case 1:{
					tempClothes.renderer.material.color = Color.yellow;
					break;
				}
				case 2:{
					tempClothes.renderer.material.color = Color.red;
					break;
				}
				case 3:{
					tempClothes.renderer.material.color = Color.gray;
					break;
				}
				case 4:{
					tempClothes.renderer.material.color = Color.magenta;
					break;
				}
				case 5:{
					tempClothes.renderer.material.color = Color.green;
					break;
				}
				}
				//tempClothes.transform.position = new Vector3(tableEdge+(tableSpace*y), tableTop, 1);
				clothes.Add(tempClothes);

				space -= clothesHeight;
			}
		}

		int chosen;

		int currentSpace = 0;
		float sp1 = 0;
		float sp2 = 0;
		float sp3 = 0;
		float sp4 = 0;
		float sp5 = 0;

		float addHeight = 0;

		ArrayList done = new ArrayList();

		while(done.Count < clothes.Count){


			chosen = Random.Range(0, clothes.Count);

			if(done.IndexOf(chosen)<0){
				switch(currentSpace){
				case 0:{
					addHeight = sp1;
					sp1 += ((GameObject)clothes[chosen]).renderer.bounds.size.y + .15f;
					break;
				}
				case 1:{
					addHeight = sp2;
					sp2 += ((GameObject)clothes[chosen]).renderer.bounds.size.y + .15f;
					break;
				}
				case 2:{
					addHeight = sp3;
					sp3 += ((GameObject)clothes[chosen]).renderer.bounds.size.y + .15f;
					break;
				}
				case 3:{
					addHeight = sp4;
					sp4 += ((GameObject)clothes[chosen]).renderer.bounds.size.y + .15f;
					break;
				}
				case 4:{
					addHeight = sp5;
					sp5 += ((GameObject)clothes[chosen]).renderer.bounds.size.y + .15f;
					break;
				}
				}

				((GameObject)clothes[chosen]).transform.position =  new Vector3(tableEdge+.2f+(tableSpace*(float)currentSpace)+(tableSpace/2f)-(((GameObject)clothes[0]).renderer.bounds.size.x/2f), tableTop+addHeight+(((GameObject)clothes[chosen]).renderer.bounds.size.y/2f), 1f);
				currentSpace = (currentSpace+1)%5;

				done.Add(chosen);
			}

		}
		/*for(int i = 0; i<clothes.Count; i++){

			chosen = Random.Range(1, 5);
			switch(chosen){
			case 1:{
				((GameObject)clothes[i]).transform.position = new Vector3(tableEdge, tableTop+yInc*sp1, 1f);
				sp1 += 1f;
				break;
			}
			case 2:{
				((GameObject)clothes[i]).transform.position = new Vector3(tableEdge+tableSpace, tableTop+yInc*sp2, 1f);
				sp2 += 1f;
				break;
			}
			case 3:{
				((GameObject)clothes[i]).transform.position = new Vector3(tableEdge+(tableSpace*2f), tableTop+yInc*sp3, 1f);
				sp3 += 1f;
				break;
			}
			case 4:{
				((GameObject)clothes[i]).transform.position = new Vector3(tableEdge+(tableSpace*3f), tableTop+yInc*sp4, 1f);
				sp4 += 1f;
				break;
			}
			case 5:{
				((GameObject)clothes[i]).transform.position = new Vector3(tableEdge+(tableSpace*4f), tableTop+yInc*sp5, 1f);
				sp5 += 1f;
				break;
			}
			}
		}*/

		//((GameObject)clothes[0]).transform.position = new Vector3(tableEdge, tableTop+yInc*1, 1f);

	}
}
