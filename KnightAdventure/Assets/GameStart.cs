using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonQuit;
    // Start is called before the first frame update
    void Start()
    {
        // start game
        Button buttonStart = this.buttonStart.GetComponent<Button>();
        buttonStart.onClick.AddListener(StartGame);
         // quit game
        Button buttonQuit = this.buttonQuit.GetComponent<Button>();
        buttonQuit.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    void QuitGame()
    {
        // end program
        UnityEditor.EditorApplication.isPlaying= false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
