using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject happy;
    public GameObject troll;
    public float startWait;
    public float waveWait;

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
            Vector2 spawnPosition = new Vector2(Random.Range(-93, 93), Random.Range(-51, 51));
            Instantiate(happy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator SpawnStaticTrolls()
    {
        while (true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-93, 93), Random.Range(-51, 51));
            Instantiate(troll, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnMovingTrolls()
    {
        while (true)
        {
            Vector2 spawnPosition = new Vector2(93, Random.Range(-51, 51));
            GameObject t = (GameObject)Instantiate(troll, spawnPosition, Quaternion.identity);
            t.GetComponent<Troll>().moving = true;
            yield return new WaitForSeconds(10.0f);
        }
    }
}