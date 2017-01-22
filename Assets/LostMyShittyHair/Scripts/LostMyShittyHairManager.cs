using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostMyShittyHairManager : MonoBehaviour {

    public Text StartingLabel;
    public Text scoreLabel;
    public GameObject gameSpawnerObject;
    public GameObject readyButton;
    public GameObject gameOverMenu;
    public GameObject newHighScoreMenu;
    public GameObject LeaderBoardMenu;
    public GameObject HighScoreContent;
    public GameObject HighScoreObjectExample;
    List<int> highScores = new List<int>();
    List<string> highScoreNames = new List<string>();
    public GameObject LoadingScreen;
    public TrumpHairController hairController;
    public Rigidbody2D hairRigidBody;
    public Text GameOverScore;
    public Text newHighScoreMenuScore;
    public InputField newHighScoreMenuName;
    string playerName;
    int score = 0;
    float countdownTimer = 4f;
    bool gameStarted = false;
    bool UserReady = false;
    private AudioSource audioSource;
    public AudioClip buttonClick;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        LoadingScreen.SetActive(false);
        gameOverMenu.SetActive(false);
        newHighScoreMenu.SetActive(false);
        LeaderBoardMenu.SetActive(false);
        hairRigidBody.isKinematic = true;
        hairController.enabled = false;
        StartingLabel.gameObject.SetActive(false);
        gameSpawnerObject.SetActive(false);

    }

    // Update is called once per frame
    string currentStartingTimer = "";
	void Update () {
        if (UserReady)
        {
            if (!gameStarted)
            {
                if (StartingLabel.text != currentStartingTimer)
                {
                    currentStartingTimer = StartingLabel.text;
                    audioSource.PlayOneShot(buttonClick);
                }

                countdownTimer -= Time.deltaTime;

                int timerShort = (int)countdownTimer;
                
                if (countdownTimer <= 1)
                {
                    StartingLabel.text = "GO!";
                }
                else
                {
                    StartingLabel.text = timerShort.ToString();
                }

                    if (countdownTimer <= 0)
                {
                    gameStarted = true;
                    StartGame();
                }
            }
        }
	}

    public void ReadyButtonClicked()
    {
        
        UserReady = true;
        readyButton.SetActive(false);
        StartingLabel.gameObject.SetActive(true);
    }

    void StartGame()
    {
        hairRigidBody.isKinematic = false;
        hairController.enabled = true;
        StartingLabel.gameObject.SetActive(false);
        gameSpawnerObject.SetActive(true);
    }

    public void AddScorePoint ()
    {
        score += 1;
        scoreLabel.text = score.ToString();
    }

    public void GameOver()
    {
        int tempScore = PlayerPrefs.GetInt("HighScore10", 0);
        if (score <= tempScore)
        {
            gameOverMenu.SetActive(true);
            GameOverScore.text = score.ToString();
        }
        else
        {
            newHighScoreMenu.SetActive(true);
            newHighScoreMenuScore.text = score.ToString();
        }


        hairRigidBody.isKinematic = true;
        hairController.enabled = false;
        gameSpawnerObject.SetActive(false);

    }

    public void SetUpLeaderBoard()
    {
        playerName = newHighScoreMenuName.text;
        CloseNewHighScoreMenu();
        AddScoreToHighScoreBoard();
        GetHighScoreBoard();
    }

    private void GetHighScoreBoard()
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

        LeaderBoardMenu.SetActive(true);
    }

    public void CloseNewHighScoreMenu()
    {
        newHighScoreMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        LeaderBoardMenu.SetActive(false);
        LoadingScreen.SetActive(true);
        StartCoroutine(WaitForLoadingScreen());
    }

    public void ResetGame()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(ResetSceneDelay());
    }

    private IEnumerator ResetSceneDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TrumpRunning");
    }

    private IEnumerator WaitForLoadingScreen()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync("MainMenu");
    }

    private void AddScoreToHighScoreBoard()
    {
        int tempScore = score;
        string tempName = playerName;

        for (int i = 0; i < 10; i++)
        {
            string highScoreNameKey = "HighScorePlayerName" + (i + 1).ToString();
            string highScoreKey = "HighScore" + (i + 1).ToString();
            string highScoreName = PlayerPrefs.GetString(highScoreNameKey, "");
            int highScore = PlayerPrefs.GetInt(highScoreKey, 0);

            if (tempScore > highScore)
            {
                int temp = highScore;
                string tempstring = highScoreName;
                PlayerPrefs.SetInt(highScoreKey, score);
                PlayerPrefs.SetString(highScoreNameKey, tempName);
                tempName = tempstring;
                tempScore = temp;
            }
        }
    }
}
