using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer : MonoBehaviour
{
    public static int maxHealth = PlayerPrefs.GetInt("MaxHP", 100);

    public static int currentHeath = PlayerPrefs.GetInt("HP", 100);

    public static int attackDamage = PlayerPrefs.GetInt("Damage", 20);

    public static int maxValueExp = PlayerPrefs.GetInt("MaxExp", 100);

    public static int valueExp = PlayerPrefs.GetInt("Exp", 0);

    public static int level = PlayerPrefs.GetInt("Level", 1);
    
}
