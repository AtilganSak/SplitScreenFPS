using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public PlayerData playerInformations;

    public TMP_Text nicknameTxt;

    public ParticleSystem deadParticle;

    public UnityEvent OnDead;

    Vector3 spawnPoint;
    Damagable damagable;
    MeshRenderer meshRenderer;

    Transform myTransform;

    private void OnEnable()
    {
        damagable = GetComponentInChildren<Damagable>();
        myTransform = GetComponent<Transform>();
        meshRenderer = GetComponent<MeshRenderer>();

        spawnPoint = myTransform.position;
    }
    private void Start()
    {
        if(nicknameTxt != null)
            nicknameTxt.text = playerInformations.nickName;
        if (meshRenderer != null)
            meshRenderer.material.SetColor("_Color", playerInformations.color);
    }
    public void ResetHealt()
    {
        if (damagable != null)
        {
            damagable.Reset();
        }
    }
    public void ReSpawn()
    {
        myTransform.position = spawnPoint;
    }
    public void Dead()
    {
        OnDead.Invoke();

        if(deadParticle != null)
            deadParticle.Play();
    }
}
