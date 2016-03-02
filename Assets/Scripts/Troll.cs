using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {
	public GameController gc;
	public MainCamera mainCamera;
	public GameObject troll2;
	public float movingTrollSpeed;
	public float movingTrollMinSize;
	public float movingTrollMaxSize;
	public int staticTrollPulseRate;
	public float staticTrollMinSize;
	public float staticTrollMaxSize;

	public bool moving;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType<GameController>();
		mainCamera = FindObjectOfType<MainCamera>();
		if (moving) {
			float s = Random.Range(movingTrollMinSize, movingTrollMaxSize);
			transform.localScale = new Vector2(s, s);
			transform.localPosition = new Vector2(150, transform.localPosition.y);
		}
		else
		{
			transform.localScale = new Vector2(staticTrollMinSize, staticTrollMinSize);
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			if (transform.localPosition.x > -150)
			{
				transform.localPosition = new Vector2(transform.localPosition.x - movingTrollSpeed * Time.deltaTime, transform.localPosition.y);
			}
			else
			{
				Destroy(gameObject);
			}
		} else {
			if(GetComponent<SpriteRenderer>().color.a < 1) {
				float a = GetComponent<SpriteRenderer>().color.a + Time.deltaTime;
				GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);
			} else {
				float s = transform.localScale.x + staticTrollPulseRate * Time.deltaTime;
				transform.localScale = new Vector2(s, s);
				if (s < staticTrollMinSize)
					staticTrollPulseRate = System.Math.Abs(staticTrollPulseRate);
				else if (s > staticTrollMaxSize)
					staticTrollPulseRate = -System.Math.Abs(staticTrollPulseRate);
			}
		}
	}

	void OnMouseEnter()
	{
		if(GetComponent<SpriteRenderer>().color.a < 1) return;
		gc.lives--;
		mainCamera.GetComponent<Camera>().backgroundColor = new Color(1f, 0, 0, 1f);
		GameObject a = Instantiate(troll2);
		a.transform.localPosition = transform.localPosition;
		a.transform.localScale = transform.localScale;
		Destroy(gameObject);
	}
}
