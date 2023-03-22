using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotHealth : MonoBehaviour
{
    public static Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = DataBot.Health;
        slider.value = slider.maxValue;

    }

    public static void SettingHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }
}
