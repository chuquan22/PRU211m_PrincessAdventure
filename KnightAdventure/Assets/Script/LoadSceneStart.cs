using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
 
        SceneManager.LoadScene("StartGame");
       // Debug.Log("Loaded");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
