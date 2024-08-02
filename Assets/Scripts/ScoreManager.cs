using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private TextMeshProUGUI scoreTxt;
    public int score = 10;
    private void Awake()
    {
        scoreTxt = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        MakeSingleton();
    }

    private void Start()
    {
        AddScore(0);
    }

    private void Update()
    {
        if (scoreTxt == null)
        {
            scoreTxt = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            scoreTxt.text = score.ToString();
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        scoreTxt.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
