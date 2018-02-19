using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static Score instance;
    public float currentScore;
    public float amountToIncrease = 100;
    public Text scoreText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("TWO SCORE IN SCENE. SECOND SCORE GAMEOBJECT: " + gameObject.name);
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //private void Start()
    //{
    //    scoreText = GetComponent<Text>();
    //}

    public void ResetScore()
    {
        currentScore = 0;
        scoreText.text = "";
    }

    public void IncreaseScore()
    {
        currentScore += amountToIncrease;
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
