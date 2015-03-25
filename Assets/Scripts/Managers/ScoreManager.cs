using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int Score;

    private Text text;

    void Awake ()
    {
        this.text = GetComponent <Text> ();
        Score = 0;
    }

    void Update ()
    {
        this.text.text = "Score: " + Score;
    }
}
