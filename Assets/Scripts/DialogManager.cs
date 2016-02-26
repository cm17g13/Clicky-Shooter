using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject textBox;
    public Text dialog;

    public TextAsset textFile;
    public string[] textLines;
    public int messageID;

    public int currentLine;
    public int endLine;

    public GameController player;

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
            currentLine += 1;
        }

        if(currentLine > endLine)
        {
            textBox.SetActive(false);
        }
    }
}
