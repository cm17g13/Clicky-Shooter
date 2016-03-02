using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Camera>().backgroundColor.b < 1) {
			float b = GetComponent<Camera>().backgroundColor.b + 2 * Time.deltaTime;
			GetComponent<Camera>().backgroundColor = new Color(1f, b, b, 1f);
		}
	}
}
