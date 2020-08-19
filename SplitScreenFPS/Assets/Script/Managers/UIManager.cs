using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject panel;

    public PlayerEndPanel player1EndPanel;
    public PlayerEndPanel player2EndPanel;

    public ScorePanel scorePanel;

    public void ShowPanel(int wonPlayer)
    {
        panel.SetActive(true);

        if (wonPlayer == 1)
        {
            player1EndPanel.SetInfo(true);
            player2EndPanel.SetInfo(false);
        }
        else
        {
            player2EndPanel.SetInfo(true);
            player1EndPanel.SetInfo(false);
        }
    }
}
