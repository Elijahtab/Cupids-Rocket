using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void SetBulletBar(float bulletTimer)
    {
        slider.value = bulletTimer;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
