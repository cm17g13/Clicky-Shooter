using UnityEngine;
using System.Collections;

public class Troll2 : MonoBehaviour {

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
			//transform.Rotate(0, 0, 1000f * Time.deltaTime);
		}
	}
}
