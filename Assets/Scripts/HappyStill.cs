using UnityEngine;
using System.Collections;

public class HappyStill : MonoBehaviour
{
    public StartController controller;
    public GameObject happy;

    // Use this for initialization
    void Start()
    {
        controller = FindObjectOfType<StartController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Destroy(gameObject);
        controller.state++;        
    }
}
