using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Player Data")]
public class PlayerData : ScriptableObject
{
    public string nickName;

    public Color color = Color.white;

    public string defaultNick;
}
