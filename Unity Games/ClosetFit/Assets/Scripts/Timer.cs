using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float currentTime = 60f;

	public bool timeUp = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTime>=0){
			currentTime -= Time.deltaTime;

			gameObject.guiText.text = currentTime.ToString("00");
		}
		else{
			timeUp = true;
		}
	}
}
