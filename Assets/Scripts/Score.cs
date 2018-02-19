using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static Score instance;
    public float currentScore;
    public float amountToIncrease = 100;
    Text scoreText;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
            Debug.LogError("TWO SCORE IN SCENE. SECOND SCORE GAMEOBJECT: " + gameObject.name);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void IncreaseScore()
    {
        currentScore += amountToIncrease;
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
