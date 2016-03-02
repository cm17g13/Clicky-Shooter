using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{

    public GameObject start;
    public GameObject tutorial;
    public GameObject textPanel;
    public Text dialog;
    public Vector2 spawnPosition = new Vector2(0, 0);


    public GameObject happyStill;
    public GameObject happy;
    public GameObject displayHappy;

    public int state;

    // Use this for initialization
    void Start()
    {
        textPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                break;
            case 1:
                dialog.text = "Too small? Thought so. (press return)";
                if (Input.GetKeyDown(KeyCode.Return))
                {   
                    state++;
                    displayHappy = (GameObject) Instantiate(happy, spawnPosition, Quaternion.identity);
                }
                break;
            case 2:
                dialog.text = "Over time, Happies will grow bigger so that it is easier to click.";
                if (Input.GetKeyDown(KeyCode.Return) || displayHappy == null)
                {
                    state++;
                    if (displayHappy == null) displayHappy = (GameObject)Instantiate(happy, spawnPosition, Quaternion.identity);
                }
                break;
            case 3:
                dialog.text = "If you don't click them in time, they get sad and disapear."; 
                if (Input.GetKeyDown(KeyCode.Return) || displayHappy == null)
                {
                    state++;
                    if (displayHappy == null) displayHappy = (GameObject)Instantiate(happy, spawnPosition, Quaternion.identity);
                }
                    break;
            case 4:
                dialog.text = "However, the bigger they grow, the less points you score.";
                if (Input.GetKeyDown(KeyCode.Return) || displayHappy == null)
                {
                    state++;
                    if (displayHappy == null) displayHappy = (GameObject)Instantiate(happy, spawnPosition, Quaternion.identity);
                }
                break;
            case 5:
                dialog.text = "The idea of the game is to click as many happies as you can.";
                if (displayHappy == null)
                {
                    state++;
                    for (int i = 0; i < 10; i++)
                    {
                        Vector2 randomSpawn = new Vector2(Random.Range(-90, 90), Random.Range(-50, 47));
                        displayHappy = (GameObject)Instantiate(happy, randomSpawn, Quaternion.identity);
                    }
                        
                }
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
        }
    }

    public void btnPlay_Clicked()
    {
        Application.LoadLevel("Main");
    }

    public void btnTut_Clicked()
    {
        start.SetActive(false);
        tutorial.SetActive(false);
        textPanel.SetActive(true);
        dialog.text = "This is a Happy. To score points, you must click on them!";
        Instantiate(happyStill, spawnPosition, Quaternion.identity);
    }


}

/*

Too boring? Yep, we know.
So here's a Troll!
Do not touch them! You will lose a life!
You have three lives.
Trolls grow and shrink.
Over time, Trolls will fill up the screen so it's harder to reach the Happies.
Stay away from the Trolls!

Still too easy?
Here come the moving Trolls!

*/
