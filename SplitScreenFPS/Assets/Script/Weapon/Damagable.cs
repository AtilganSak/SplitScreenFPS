using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    public bool deadSelf;

    public float maxHealt;
    public float healt;

    public UnityEvent OnDead;

    public bool changeColor;
    public MeshRenderer renderer;
    public Color switchToColor;

    public Image healtBar;

    Color defautlColor;

    Material mat;

    private void OnEnable()
    {
        if (changeColor)
        {
            mat = renderer.material;
            defautlColor = mat.GetColor("_BaseColor");
        }
    }
    private void Start()
    {
        if(healt > maxHealt)
        {
            healt = maxHealt;
        }

        if (healtBar != null)
            healtBar.fillAmount = healt / maxHealt;
    }
    public void Reset()
    {
        healt = 100;

        if (healtBar != null)
            healtBar.fillAmount = healt / maxHealt;
    }
    public void HealtBoost(float _amount)
    {
        float newHealt = healt + _amount;
        if(newHealt < maxHealt && newHealt > healt)
        {
            healt = newHealt;
        }
        else
        {
            healt = maxHealt;
        }
    }
    public void GiveDamage(float _amount)
    {
        float newHealt = healt - _amount;

        if (healtBar != null)
            healtBar.fillAmount = healt / maxHealt;

        if(newHealt <= 0)
        {
            healt = 0;
            if(deadSelf)
            {
                Destroy(gameObject);
            }
            else
            {
                if(OnDead.GetPersistentEventCount() > 0)
                {
                    OnDead.Invoke();
                }
            }
        }
        else
        {
            healt = newHealt;

            if (changeColor)
            {
                float t = Mathf.InverseLerp(maxHealt, 0, newHealt);
                Color currentColor = Color.Lerp(defautlColor, switchToColor, t);
                mat.SetColor("_BaseColor", currentColor);

                renderer.material = mat;
            }
        }
    }
}
