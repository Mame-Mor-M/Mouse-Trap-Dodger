using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // To use UI code features

public class ScoreTextScript : MonoBehaviour
{
    static Text text;
    public static int cheeseAmount; // Number of cheese collected
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = cheeseAmount.ToString(); // Converts the amount of cheese collected into a string of text

    }
}
