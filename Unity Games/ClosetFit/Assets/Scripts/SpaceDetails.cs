using UnityEngine;
using System.Collections;

public class SpaceDetails : MonoBehaviour {

	public float space1;
	public float space2;
	public float space3;
	public float space4;
	public float edge;
	public float top;
	public float bottom;

	public int space1_count;
	public int space2_count;
	public int space3_count;
	public int space4_count;

	// Use this for initialization
	void Start () {
		Vector3 spaceSize = gameObject.renderer.bounds.size;
		Vector3 spaceLoc = gameObject.transform.position;

		space1 = spaceLoc.x - spaceSize.x/2f;
		space2 = space1 + spaceSize.x/4f;
		space3 = space2 + spaceSize.x/4f;
		space4 = space3 + spaceSize.x/4f;
		edge = space4 + spaceSize.x/4f;
		top = spaceLoc.y + spaceSize.y/2f;
		bottom = spaceLoc.y - spaceSize.y/2f;

		space1_count = 8;
		space2_count = 8;
		space3_count = 8;
		space4_count = 8;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
