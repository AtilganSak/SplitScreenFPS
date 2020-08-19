using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControlPanel : MonoBehaviour
{
    public TMP_InputField nickNameField;
    public PlayerData playerData;

    public Image background;
    public Image blockPanel;

    public float changeColorSpeed = 3;

    public Action<bool> readyForPlay;

    public AudioClip buttonClickSound;

    AudioSource audioSource;

    Color selectedPlayerColor = Color.white;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        blockPanel.enabled = false;
    }
    private void Update()
    {
        background.color = Color.Lerp(background.color, selectedPlayerColor, Time.deltaTime * changeColorSpeed);
    }
    public void SelectedRed()
    {
        if (!selectedPlayerColor.Compare(Color.red))
        {
            selectedPlayerColor = Color.red;
        }
        audioSource.PlayOneShot(buttonClickSound);
    }
    public void SelectedYellow()
    {
        if (!selectedPlayerColor.Compare(Color.yellow))
        {
            selectedPlayerColor = Color.yellow;
        }
        audioSource.PlayOneShot(buttonClickSound);
    }
    public void SelectedGreen()
    {
        if (!selectedPlayerColor.Compare(Color.green))
        {
            selectedPlayerColor = Color.green;
        }
        audioSource.PlayOneShot(buttonClickSound);
    }
    public void SelectedBlue()
    {
        if (!selectedPlayerColor.Compare(Color.blue))
        {
            selectedPlayerColor = Color.blue;
        }
        audioSource.PlayOneShot(buttonClickSound);
    }
    void SetPlayerData()
    {
        if (nickNameField != null)
        {
            if (nickNameField.text == "")
            {
                playerData.nickName = playerData.defaultNick;
            }
            else
            {
                playerData.nickName = nickNameField.text;
            }
        }
        playerData.color = selectedPlayerColor;
    }
    public void Ready()
    {
        SetPlayerData();

        blockPanel.enabled = true;

        audioSource.PlayOneShot(buttonClickSound);

        readyForPlay.Invoke(true);
    }
    public void UnReady()
    {
        blockPanel.enabled = false;

        audioSource.PlayOneShot(buttonClickSound);

        readyForPlay.Invoke(false);
    }
}
