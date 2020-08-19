using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1;
    public Player player2;

    public float winScore = 3;

    int player1Score;
    int player2Score;

    UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();

        player1.OnDead.AddListener(Player1IsDead);
        player2.OnDead.AddListener(Player2IsDead);
    }
    private void OnDisable()
    {
        player1.OnDead.RemoveListener(Player1IsDead);
        player2.OnDead.RemoveListener(Player2IsDead);
    }
    void Player1IsDead()
    {
        player2Score++;
        uiManager.scorePanel.UpdateScore(player1Score, player2Score);
        if (!ControlScores())
            ReSpawnPlayers();
    }
    void Player2IsDead()
    {
        player1Score++;
        uiManager.scorePanel.UpdateScore(player1Score, player2Score);
        if (!ControlScores())
            ReSpawnPlayers();
    }
    void ReSpawnPlayers()
    {
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);

        player1.ResetHealt();
        player2.ResetHealt();

        player1.ReSpawn();
        player2.ReSpawn();
    }
    bool ControlScores()
    {
        if (player1Score == winScore)
        {
            uiManager.ShowPanel(1);
            Time.timeScale = 0;

            return true;
        }
        else if(player2Score == winScore)
        {
            uiManager.ShowPanel(2);
            Time.timeScale = 0;

            return true;
        }
        return false;
    }
}
