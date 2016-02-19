using UnityEngine;
using System.Collections;

public class Troll : MonoBehaviour {

    public bool moving;

	// Use this for initialization
	void Start () {
        if (moving) {
            float s = Random.Range(1, 25);
            transform.localScale = new Vector2(s, s);
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
        }
	}

    void OnMouseEnter()
    {
        Destroy(gameObject);
    }
}
