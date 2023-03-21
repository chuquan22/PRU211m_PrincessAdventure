using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public Button btnContinue;
    public Button btnQuit;
    // Start is called before the first frame update
    void Start()
    {
        Button btnContinue = this.btnContinue.GetComponent<Button>();
        btnContinue.onClick.AddListener(Continue);
        Button btnQuit = this.btnQuit.GetComponent<Button>();
        btnQuit.onClick.AddListener(Quit);
    }

    void Continue()
    {

    }

     void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
