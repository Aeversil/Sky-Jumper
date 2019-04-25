using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public Transform player;
    float playerHeightY;

    public Transform normal;
    public Transform LeftRight;
    public Transform UpDown;

    private int platNumber;

    private float platCheck;
    private float spawnPlatformsTo;

    private static int score;
    private int highScore;
    private int deathScore;
    private bool death = false;
    public Text scoreLabel;
    public Text highScoreText;
    public Text scoreLabelDeath;

    void PlatformManager()
    {
        platCheck = player.position.y + 10;
        PlatformSpawner(platCheck + 15);
    }

    // loads highscore from player pref file
    void LoadhighScore()
    {
        highScore = PlayerPrefs.GetInt("Highscore1", highScore);
        highScoreText.text = highScore.ToString();

    }

    void GetDeathScore()
    {
        deathScore = PlayerPrefs.GetInt("DeathScore", deathScore);
        scoreLabelDeath.text = score.ToString();
    }

    // Spwans the platforms
    void PlatformSpawner(float SpawnPoint)
    {
        float y = spawnPlatformsTo;

        while(y <= SpawnPoint)
        {
            float x = Random.Range(-3.05f, 3.05f);

            platNumber = Random.Range(1, 4);

            Vector2 posXY = new Vector2(x, y);

            if (platNumber == 1)
            {
                Instantiate(normal, posXY, Quaternion.identity);
            }

            if (platNumber == 2)
            {
                Instantiate(UpDown, posXY, Quaternion.identity);
            }

            if (platNumber == 3)
            {
                Instantiate(LeftRight, posXY, Quaternion.identity);
            }

            y += Random.Range(.5f, 1.75f);
        }

        spawnPlatformsTo = SpawnPoint;
    }
    // Sets highscore in player pref file
    void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "" + score;

            PlayerPrefs.SetInt("Highscore1", highScore);
        }
    }
    // Runs on start
    void Start()
    {
        CheckHighScore();

        highScoreText = GetComponent<Text>();

        score = 0;

        highScore = PlayerPrefs.GetInt("Highscore1", highScore);
        highScoreText.text = highScore.ToString();
    }

    

    // Update is called once per frame
    void Update()
    {
        CheckHighScore();

        //Move camera along with player hight
        playerHeightY = player.position.y;

        if (playerHeightY > platCheck)
        {
            PlatformManager();
        }

        float currentCameraHeight = transform.position.y;

        float newCameraHeight = Mathf.Lerp(currentCameraHeight, playerHeightY, Time.deltaTime * 10);

        if (playerHeightY > currentCameraHeight)
        {
            transform.position = new Vector3(transform.position.x, newCameraHeight, transform.position.z);
        }
        else
        {
            //Kill player when he falls below camera
            if (playerHeightY < (currentCameraHeight - 5.5))
            {
                death = true;

                if (death == true)
                {
                    PlayerPrefs.SetInt("DeathScore", score);

                    scoreLabelDeath.text = deathScore.ToString();

                }

                SceneManager.LoadScene(2);
            }
        }

        if (playerHeightY > score)
        {
            score = (int)playerHeightY;
            scoreLabel.text = "Score: " + score;
        }

    }

    void Awake()
    {
        LoadhighScore();
        GetDeathScore();
    }
}
