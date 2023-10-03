using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textMeshProUGUI;
    [SerializeField]private TextMeshProUGUI highScoreText;
    [SerializeField]private TextMeshProUGUI moneyText;
    private int score = 0;
    private MoneyController moneyController;
    void Start()
    {
        textMeshProUGUI.text = "Score:";
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
        moneyController = GetComponent<MoneyController>();
    }

    private void OnEnable()
    {
        EnemyHandler.onDeath += updateScore;
        PlayerHealth.onDeath += updateMoneyCount;
    }

    private void OnDisable()
    {
        EnemyHandler.onDeath -= updateScore;
        PlayerHealth.onDeath -= updateMoneyCount;
    }

    private void updateScore()
    {
        score += 100;
        textMeshProUGUI.text = $"Score: {score}"; 
        checkHighScore();
    }

    private void checkHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore",  0)){

            PlayerPrefs.SetInt("HighScore", score);
            updateHighScoreText();
        }
    }

    private void updateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    private void updateMoneyCount()
    {
        int money = moneyController.converstScoreToMoney(score);
        moneyText.text = $"Money: {money}";
    }

}
