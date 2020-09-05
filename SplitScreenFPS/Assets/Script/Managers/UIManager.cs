using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

public class UIManager : MonoBehaviour
{
    public GameObject panel;

    public PlayerEndPanel player1EndPanel;
    public PlayerEndPanel player2EndPanel;

    public ScorePanel scorePanel;

    int counter;

    WaitForSeconds waitFor;

    private void Start()
    {
        waitFor = new WaitForSeconds(1);

        counter = 5;
    }
    public void ShowEndPanel(int wonPlayer)
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
        StartCoroutine(TimeTick());
    }
    IEnumerator TimeTick()
    {
        player1EndPanel.timeText.text = "Returning menu in " + counter.ToString() + "sn";
        player2EndPanel.timeText.text = "Returning menu in " + counter.ToString() + "sn";
        while (true)
        {
            counter--;
            if (counter < 0)
            {
                counter = 0;
                break;
            }
            player1EndPanel.timeText.text = "Returning menu in " + counter.ToString() + "sn";
            player2EndPanel.timeText.text = "Returning menu in " + counter.ToString() + "sn";
            yield return waitFor;
        }
        SceneManager.LoadScene(0);
    }
}
