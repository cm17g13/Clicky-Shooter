using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject textBox;
    public GameObject skipButton;
    public Text dialog;

    public TextAsset textFile;
    public string[] textLines;
    public int messageID;

    public int currentLine;
    public int endLine;

    void Start()
    {
        if (textFile != null) {
            //textLines = (textFile.text.Split("\n\n")[messageID].Split('\n'));
            textLines = (textFile.text.Split('\n'));
        }

        if (endLine == 0) {
            endLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        dialog.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentLine == endLine)
            {
                skipButton.SetActive(false);
                textBox.SetActive(false);
            } else
            {
                currentLine += 1;
            }  
        }


    }
}
