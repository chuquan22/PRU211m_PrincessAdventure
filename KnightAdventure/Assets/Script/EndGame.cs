using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonMenu;
    // Start is called before the first frame update
    void Start()
    {
        Button buttonRestart = this.buttonRestart.GetComponent<Button>();
        Button buttonMenu = this.buttonMenu.GetComponent<Button>();
        buttonRestart.onClick.AddListener(Restart);
        buttonMenu.onClick.AddListener(MainMenu);
    }

    void Restart()
    {
        SceneManager.LoadScene("Map1");
    }

    void MainMenu()
    {
        SceneManager.LoadScene("StartGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
