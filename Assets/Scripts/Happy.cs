using UnityEngine;
using System.Collections;

public class Happy : MonoBehaviour {
    public GameController gc;
	public GameObject sad;
    public float countdown;
	public bool fading;

	// Use this for initialization
	void Start () {
        gc = FindObjectOfType<GameController>();
		fading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fading) {
			if(GetComponent<SpriteRenderer>().color.a <= 0) {
				Destroy(gameObject);
			} else {
				float a = GetComponent<SpriteRenderer>().color.a - 5 * Time.deltaTime;
				GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, a);
			}
		} else if (countdown <= 0) {
            GameObject a = Instantiate(sad);
			a.transform.localPosition = transform.localPosition;
			a.transform.localScale = transform.localScale;
			Destroy(gameObject);
        } else {
            countdown -= Time.deltaTime;
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime);
            GetComponent<CircleCollider2D>().transform.localScale = transform.localScale;
        }
    }

    void OnMouseDown()
    {
		if(!fading) {
			GameController.score += (int)(countdown * 100);
			fading = true;
		}
    }
}
