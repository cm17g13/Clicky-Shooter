﻿using UnityEngine;
using System.Collections;

public class Happy : MonoBehaviour {

    public float countdown;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            countdown -= Time.deltaTime;
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime);
            GetComponent<CircleCollider2D>().transform.localScale = transform.localScale;
        }
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}