using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LostMyShittyHairManager : MonoBehaviour {

    public Text StartingLabel;
    public Text scoreLabel;
    public GameObject gameSpawnerObject;
    public GameObject readyButton;
    public GameObject gameOverMenu;
    public TrumpHairController hairController;
    public Rigidbody2D hairRigidBody;
    public Text GameOverScore;
    int score = 0;
    float countdownTimer = 4f;
    bool gameStarted = false;
    bool UserReady = false;

	// Use this for initialization
	void Start () {
        hairRigidBody.isKinematic = true;
        hairController.enabled = false;
        StartingLabel.gameObject.SetActive(false);
        gameSpawnerObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (UserReady)
        {
            if (!gameStarted)
            {
                countdownTimer -= Time.deltaTime;

                int timerShort = (int)countdownTimer;
                StartingLabel.text = timerShort.ToString();

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
        gameOverMenu.SetActive(true);
        GameOverScore.text = score.ToString();
        hairRigidBody.isKinematic = true;
        hairController.enabled = false;
        gameSpawnerObject.SetActive(false);

    }

    public void ResetGame()
    {
        SceneManager.LoadScene("TrumpRunning");
    }
}
