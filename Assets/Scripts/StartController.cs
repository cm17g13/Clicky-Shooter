using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartController : MonoBehaviour
{

    public GameObject start;
    public GameObject tutorial;
    public GameObject textPanel;
    public GameObject objectivePanel;
    public Text objective;
    public Text dialog;
    public GameObject[] happyList;
    public GameObject[] trollList;
    public Vector2 spawnPosition = new Vector2(0, 0);


    public GameObject happyStill;
    public GameObject happy;
    public GameObject troll;
    public GameObject displayHappy;
    public GameObject displayTroll;

    public int state;

    // Use this for initialization
    void Start()
    {
        objectivePanel.SetActive(false);
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
                dialog.text = "Too simple? press return or complete the objective on each page to move on";
                objective.text = "Press return";
                if (Input.GetKeyDown(KeyCode.Return))
                {   
                    state++;
                    displayHappy = (GameObject) Instantiate(happy, spawnPosition, Quaternion.identity);
                }
                break;
            case 2:
                dialog.text = "Over time, Happies will grow bigger so that it is easier to click.";
                objective.text = "Press return, click on the smiley or wait";
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
                objective.text = "Click on the smiley or wait";
                if (displayHappy == null)
                {
                    state++;
                    happyList = new GameObject[10];
                    for (int i = 0; i < 10; i++)
                    {
                        Vector2 randomSpawn = new Vector2(UnityEngine.Random.Range(-90, 90), UnityEngine.Random.Range(-50, 47));
                        happyList[i] = (GameObject)Instantiate(happy, randomSpawn, Quaternion.identity);
                    }
                        
                }
                break;
            case 6:
                dialog.text = "So, now you're ready to go out and play the game";
                objective.text = "Click on all the smileys or wait";
                if (isListNull(happyList, 10))
                {
                    Array.Clear(happyList, 0, 10);
                    state++;
                }
                break;
            case 7:
                dialog.text = "Wait? thats way to easy. You need a challenge";
                objective.text = "press return";
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    state++;
                    displayTroll = (GameObject)Instantiate(troll, spawnPosition, Quaternion.identity);
                }
                break;
            case 8:
                dialog.text = "This is a troll, Do not touch them! You will lose a life!";
                objective.text = "Press return or mouse over the troll";
                if (Input.GetKeyDown(KeyCode.Return) || displayTroll == null)
                {
                    state++;
                    Destroy(displayTroll);
                    trollList = new GameObject[3];
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 randomSpawn = new Vector2(UnityEngine.Random.Range(-96, 96), UnityEngine.Random.Range(-54, 54));
                        trollList[i] = (GameObject)Instantiate(troll, randomSpawn, Quaternion.identity);
                    }
                }
                break;
            case 9:
                dialog.text = "You have 3 lives, go on, lose them all, you know you want too";
                objective.text = "Mouse over all the trolls";
                if (isListNull(trollList, 3))
                {
                    state++;
                    Array.Clear(trollList, 0, 3);
                    GameObject t = (GameObject)Instantiate(troll);
                    t.GetComponent<TrollTutorial>().moving = true;
                    displayTroll = t;
                }
                    break;
            case 10:
                dialog.text = "Every few trolls move, but they only spawn on the right and move left";
                objective.text = "Press return or mouse over the troll";
                if (Input.GetKeyDown(KeyCode.Return) || displayTroll == null)
                {
                    state++;
                    Destroy(displayTroll);
                    trollList = new GameObject[10];
                    for (int i = 0; i < 10; i++)
                    {           
                        if (i == 0)
                        {
                            GameObject t = (GameObject)Instantiate(troll);
                            t.GetComponent<TrollTutorial>().moving = true;
                            trollList[i] = t;
                        } else {
                           Vector2 randomSpawn = new Vector2(UnityEngine.Random.Range(-96, 96), UnityEngine.Random.Range(-54, 54));
                           trollList[i] = (GameObject)Instantiate(troll, randomSpawn, Quaternion.identity);
                        }
                    }
                }
                break;
            case 11:
                dialog.text = "This is just a small example of how chaotic it can get ";
                objective.text = "Press return or mouse over all the trolls";
                if (Input.GetKeyDown(KeyCode.Return) || isListNull(trollList, 10))
                {
                    state++;
                    for (int i = 0; i < 10; i++)
                    {
                        Destroy(trollList[i]);
                    }
                }
                    break;
            case 12:
                dialog.text = "Okay, you're ready for the full game now!";
                objective.text = "What does this button do?";
                start.SetActive(true);
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            case 17:
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
        objectivePanel.SetActive(true);
        dialog.text = "This is a Happy. To score points, you must click on them!";
        objective.text = "Click on the smiley";
        Instantiate(happyStill, spawnPosition, Quaternion.identity);
    }

    public bool isListNull(GameObject[] list, int length)
    {
        for (int i = 0; i < length; i++)
        {
            if (list[i] != null) return false;
        }
        return true;
    }



}

