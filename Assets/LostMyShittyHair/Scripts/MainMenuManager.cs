using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public GameObject HighScoreMenu;
    public GameObject LoadingScreen;
    public GameObject HighScoreContent;
    public GameObject HighScoreObjectExample;
    List<int> highScores = new List<int>();
    List<string> highScoreNames = new List<string>();

    // Use this for initialization
    void Start () {

        int highScore = PlayerPrefs.GetInt("HighScore1", 0);
        if (highScore == 0)
        {
            SetInitalHighScores();
        }

        LoadingScreen.SetActive(false);
        HighScoreMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetInitalHighScores()
    {
        PlayerPrefs.SetString("HighScorePlayerName1", "Putin");
        PlayerPrefs.SetInt("HighScore1", 500);

        PlayerPrefs.SetString("HighScorePlayerName2", "Rex Tillerson");
        PlayerPrefs.SetInt("HighScore2", 400);

        PlayerPrefs.SetString("HighScorePlayerName3", "Steven Mnuchin");
        PlayerPrefs.SetInt("HighScore3", 250);

        PlayerPrefs.SetString("HighScorePlayerName4", "Tom Price");
        PlayerPrefs.SetInt("HighScore4", 200);

        PlayerPrefs.SetString("HighScorePlayerName5", "Rick Perry");
        PlayerPrefs.SetInt("HighScore5", 100);

        PlayerPrefs.SetString("HighScorePlayerName6", "Betsy DeVos");
        PlayerPrefs.SetInt("HighScore6", 50);

        PlayerPrefs.SetString("HighScorePlayerName7", "Jeff Sessions");
        PlayerPrefs.SetInt("HighScore7", 30);

        PlayerPrefs.SetString("HighScorePlayerName8", "Stephen Bannon");
        PlayerPrefs.SetInt("HighScore8", 20);

        PlayerPrefs.SetString("HighScorePlayerName9", "Ben Carson");
        PlayerPrefs.SetInt("HighScore9", 10);

        PlayerPrefs.SetString("HighScorePlayerName10", "Chris Christie");
        PlayerPrefs.SetInt("HighScore10", 5);
    }

    public void GetHighScroreBoard()
    {
        if (highScores.Count == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                string highScoreKey = "HighScore" + (i + 1).ToString();
                string highScoreNameKey = "HighScorePlayerName" + (i + 1).ToString();
                int highScore = PlayerPrefs.GetInt(highScoreKey, 0);
                string highScoreName = PlayerPrefs.GetString(highScoreNameKey, "");
                highScores.Add(highScore);
                highScoreNames.Add(highScoreName);
            }

            for (int i = 0; i < 10; i++)
            {
                GameObject scorePanel = Instantiate(HighScoreObjectExample, HighScoreObjectExample.transform.position, HighScoreObjectExample.transform.rotation);
                scorePanel.transform.parent = HighScoreContent.transform;
                scorePanel.transform.position = new Vector3(0, 0, 0);
                HighScorePlacementController highscoreController = scorePanel.GetComponent<HighScorePlacementController>();
                highscoreController.SetHighScoreValues(i + 1, highScoreNames[i], highScores[i]);
            }
        }

        HighScoreMenu.SetActive(true);
    }
   
    public void CloseHighScore()
    {
        HighScoreMenu.SetActive(false);
    }

    public void StartGame()
    {
        //Start Loading Game and Show loading screen
        LoadingScreen.SetActive(true);
        StartCoroutine(WaitForLoadingScreen());
    }

    private IEnumerator WaitForLoadingScreen()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync("TrumpRunning");
    }
}
