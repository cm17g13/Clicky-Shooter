using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject happy;
	public GameObject troll;
	public float happyRate;
	public float staticTrollRate;
	public float movingTrollRate;

	public Text livesText;
	public Text timeText;
	public Text scoreText;

	public int lives;
	public float time;
	public static int score;

	void Start()
	{
		score = 0;
		StartCoroutine(SpawnHappies());
		StartCoroutine(SpawnStaticTrolls());
		StartCoroutine(SpawnMovingTrolls());
	}

	void Update()
	{
		livesText.text = "" + lives;
		timeText.text = "Time: " + (int)System.Math.Floor(time) + " seconds";
		scoreText.text = "Score: " + score;
		time -= Time.deltaTime;

		if(time <= 0 || lives <= 0) {
			SceneManager.LoadScene("GameOver");
		}
	}

	IEnumerator SpawnHappies()
	{
		while (true) {
			Vector2 spawnPosition = new Vector2(Random.Range(-90, 90), Random.Range(-50, 47));
			Instantiate(happy, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds(happyRate);
		}
	}

	IEnumerator SpawnStaticTrolls()
	{
		while (true) {
			Vector2 spawnPosition = new Vector2(Random.Range(-96, 96), Random.Range(-54, 54));
			Instantiate(troll, spawnPosition, Quaternion.identity);
			yield return new WaitForSeconds(staticTrollRate);
		}
	}

	IEnumerator SpawnMovingTrolls()
	{
		while (true) {
			GameObject t = (GameObject)Instantiate(troll);
			t.GetComponent<Troll>().moving = true;
			yield return new WaitForSeconds(movingTrollRate);
		}
	}
}