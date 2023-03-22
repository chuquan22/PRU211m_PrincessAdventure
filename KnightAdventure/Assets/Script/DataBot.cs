using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBot : MonoBehaviour
{
    public static int Health = PlayerPrefs.GetInt("HPBot", 100);
    public static int Attack = PlayerPrefs.GetInt("BotDamage", 10);
}
