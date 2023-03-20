using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Slider slider;
    

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = DataPlayer.maxHealth;
        slider.value = slider.maxValue;
        
    }

    public static void SettingHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }

    public static void Heart()
    {
        DataPlayer.maxHealth += 5;
        slider.value = DataPlayer.maxHealth;
    }


}
