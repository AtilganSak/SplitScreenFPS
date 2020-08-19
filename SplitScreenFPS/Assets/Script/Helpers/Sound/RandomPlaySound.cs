using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlaySound : MonoBehaviour
{
    public bool oneShoot;

    public AudioClip[] audioClips;

    AudioSource source;

    private void OnEnable()
    {
        source = GetComponent<AudioSource>();
        if (source == null) enabled = false;
    }
    void Start()
    {
        if (!oneShoot)
        {
            source.clip = audioClips[Random.Range(0, audioClips.Length)];
            source.Play();
        }
        else
        {
            source.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
        }
    }
}
