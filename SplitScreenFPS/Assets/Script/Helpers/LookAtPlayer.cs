using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public string playerTag;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player, Vector3.up);
        }
    }
}
