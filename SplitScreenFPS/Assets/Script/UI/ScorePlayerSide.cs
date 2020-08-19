using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayerSide : MonoBehaviour
{
    public Image player1ColorImage;
    public TMP_Text player1ScoreText;

    public Image player2ColorImage;
    public TMP_Text player2ScoreText;

    public void SetColor(Color player1Color, Color player2Color)
    {
        if (player1ColorImage != null)
            player1ColorImage.color = player1Color;
        if (player2ColorImage != null)
            player2ColorImage.color = player2Color;
    }
    public void UpdateScore(int pl1Score, int pl2Score)
    {
        player1ScoreText.text = pl1Score.ToString();
        player2ScoreText.text = pl2Score.ToString();
    }
}
