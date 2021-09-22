using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{
    public Slider slider;

    public void SetEnergy(float energyValue)
    {
        slider.value = energyValue;
    }
}
