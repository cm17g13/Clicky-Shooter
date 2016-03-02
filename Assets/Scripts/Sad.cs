using UnityEngine;
using System.Collections;

public class Sad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<SpriteRenderer>().color.a <= 0) {
				Destroy(gameObject);
		} else {
			float a = GetComponent<SpriteRenderer>().color.a - 2 * Time.deltaTime;
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);
		}
	}
}
