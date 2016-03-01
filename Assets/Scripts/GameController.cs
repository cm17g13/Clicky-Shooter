using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject happy;
	public GameObject troll;

	public int lives;
	public Text livesText;

	public int score;
	public Text scoreText;

	void Start()
	{
		StartCoroutine(SpawnHappies());
		StartCoroutine(SpawnStaticTrolls());
		StartCoroutine(SpawnMovingTrolls());
	}

	void Update()
	{
		livesText.text = "" + lives;
		scoreText.text = "" + score;
	}

	IEnumerator SpawnHappies()
	{
		while (true)
		{
			Vector2 spawnPosition = new Vector2(Random.Range(-90, 90), Random.Range(-50, 50));
			GameObject a = (GameObject)Instantiate(happy, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator SpawnStaticTrolls()
	{
		while (true)
		{
			Vector2 spawnPosition = new Vector2(Random.Range(-96, 96), Random.Range(-54, 54));
			GameObject a = (GameObject)Instantiate(troll, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds(5.0f);
		}
	}

	IEnumerator SpawnMovingTrolls()
	{
		while (true)
		{
			GameObject t = (GameObject)Instantiate(troll);
			t.GetComponent<Troll>().moving = true;
			yield return new WaitForSeconds(10.0f);
		}
	}
}