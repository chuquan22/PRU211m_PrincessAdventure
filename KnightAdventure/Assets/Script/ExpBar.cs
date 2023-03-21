using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBar : MonoBehaviour
{
    public static Slider slider;
    public TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = DataPlayer.maxValueExp;
        slider.value = DataPlayer.valueExp;
        BotController.OnBotDeath += increaseExp;
        textMeshPro.text = DataPlayer.level.ToString();
    }

    

    public void increaseExp()
    {
        slider.value = DataPlayer.valueExp += 10;
        if (slider.value == slider.maxValue)
        {
            DataPlayer.maxHealth += 20;
            DataPlayer.maxValueExp += 20;
            DataPlayer.attackDamage += 3;
            DataPlayer.valueExp = 0;
            DataPlayer.level += 1;
            textMeshPro.text = DataPlayer.level.ToString();
        }
    }

    
}
