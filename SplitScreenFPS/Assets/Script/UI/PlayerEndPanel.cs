using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEndPanel : MonoBehaviour
{
    public TMP_Text winText;
    public TMP_Text timeText;

    public void SetInfo(bool win)
    {
        if (win)
        {
            winText.text = "You won!";
            winText.color = Color.green;
            timeText.color = Color.green;
        }
        else
        {
            winText.text = "You lose!";
            winText.color = Color.red;
            timeText.color = Color.red;
        }
    }
}
