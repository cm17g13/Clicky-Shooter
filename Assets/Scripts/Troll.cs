using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {
	public GameController gc;
	public bool moving;
	public int pulseRate;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType<GameController>();
		if (moving) {
			float s = Random.Range(10, 25);
			transform.localScale = new Vector2(s, s);
			transform.localPosition = new Vector2(96 + s, transform.localPosition.y);
		}
		else
		{
			transform.localScale = new Vector2(5f, 5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			if (transform.localPosition.x > -120)
			{
				transform.localPosition = new Vector2(transform.localPosition.x - 10 * Time.deltaTime, transform.localPosition.y);
			}
			else
			{
				Destroy(gameObject);
			}
		} else
		{
			float s = transform.localScale.x + pulseRate * Time.deltaTime;
			if (s <= 5 || s >= 10) pulseRate = -pulseRate;
			transform.localScale = new Vector2(s, s);
		}
	}

	void OnMouseEnter()
	{
		gc.lives--;
		Destroy(gameObject);
	}
}
