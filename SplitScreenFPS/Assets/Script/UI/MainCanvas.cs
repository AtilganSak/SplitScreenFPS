using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    public PlayerControlPanel player1Panel;
    public PlayerControlPanel player2Panel;

    public GameObject playerControlMenu;

    public SoundLerp backgroundSound;

    int readyPlayerCount;

    private void OnEnable()
    {
        player1Panel.readyForPlay += Player1Ready;
        player2Panel.readyForPlay += Player2Ready;
    }
    private void OnDisable()
    {
        player1Panel.readyForPlay -= Player1Ready;
        player2Panel.readyForPlay -= Player2Ready;
    }
    void Player1Ready(bool state)
    {
        if (state)
        {
            readyPlayerCount++;
        }
        else
        {
            readyPlayerCount--;
            if (readyPlayerCount < 0)
                readyPlayerCount = 0;
        }
        ControlForPlayGame();
    }
    void Player2Ready(bool state)
    {
        if (state)
        {
            readyPlayerCount++;
        }
        else
        {
            readyPlayerCount--;
            if (readyPlayerCount < 0)
                readyPlayerCount = 0;
        }
        ControlForPlayGame();
    }
    void ControlForPlayGame()
    {
        if (readyPlayerCount >= 2)
        {
            backgroundSound.targetVol = 0;
            backgroundSound.speed = 0.7f;
            backgroundSound.enabled = true;

            SceneManager.LoadScene(1);
        }
    }
}
