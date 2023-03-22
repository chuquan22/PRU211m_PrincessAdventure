using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CotTruyen : MonoBehaviour
{
    private int currentPage = 1;
    private const int MAX_PAGE = 2;
    public Button buttonStart;
    public Button buttonNext;
    public Button buttonPrevious;
    public GameObject textCotTruyen;
    public GameObject textCotTruyen2;
    public GameObject textWelcome;
    public GameObject textEnd;
    // Start is called before the first frame update
    void Start()
    {
        buttonPrevious.GetComponent<Button>().onClick.AddListener(Previous);
        buttonNext.GetComponent<Button>().onClick.AddListener(Next);
        buttonStart.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Map1");
    }

    void Next()
    {
        currentPage++;
        textWelcome.gameObject.SetActive(false);
        textEnd.gameObject.SetActive(true);
        textCotTruyen2.gameObject.SetActive(true);
        textCotTruyen.gameObject.SetActive(false);
    }

    void Previous()
    {
        currentPage--; 
        textWelcome.gameObject.SetActive(true);
        textEnd.gameObject.SetActive(false);
        textCotTruyen2.gameObject.SetActive(false);
        textCotTruyen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPage == MAX_PAGE)
        {
            buttonPrevious.GetComponent<Button>().gameObject.SetActive(true);
            buttonPrevious.GetComponent<Button>().enabled = true;
            buttonNext.GetComponent<Button>().gameObject.SetActive(false);
            buttonNext.GetComponent<Button>().enabled = false;

        }
        else
        {

            buttonPrevious.GetComponent<Button>().gameObject.SetActive(false);
            buttonPrevious.GetComponent<Button>().enabled = false;
            buttonNext.GetComponent<Button>().gameObject.SetActive(true);
            buttonNext.GetComponent<Button>().enabled = true;
        }
        
    }
}
