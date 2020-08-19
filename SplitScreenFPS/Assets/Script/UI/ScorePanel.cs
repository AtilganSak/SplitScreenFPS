using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public ScorePlayerSide player1Side;
    public ScorePlayerSide player2Side;

    public PlayerData player1Data;
    public PlayerData player2Data;

    private void Start()
    {
        SetColor();
    }
    void SetColor()
    {
        if (player1Side != null)
            player1Side.SetColor(player1Data.color, player2Data.color);
        if (player2Side != null)
            player2Side.SetColor(player1Data.color, player2Data.color);
    }
    public void UpdateScore(int pl1Score, int pl2Score)
    {
        player1Side.UpdateScore(pl1Score, pl2Score);
        player2Side.UpdateScore(pl1Score, pl2Score);
    }
}
