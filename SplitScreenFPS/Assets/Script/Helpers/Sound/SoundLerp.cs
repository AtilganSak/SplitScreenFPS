using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLerp : MonoBehaviour
{
    public float targetVol = 1;

    public float speed;

    public float currentVol { get; set; }

    AudioSource source;
    private void OnEnable()
    {
        source = GetComponent<AudioSource>();
        if (source == null) enabled = false;

        currentVol = source.volume;
    }
    private void Update()
    {
        currentVol = Mathf.Lerp(currentVol, targetVol, Time.deltaTime * speed);
        source.volume = currentVol;
        if (Mathf.Abs(targetVol - currentVol) < 0.01f)
        {
            currentVol = targetVol;

            enabled = false;
        }
    }
}
