using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI startText;
    public static bool isGameActive = false;
    public Button restartButton;
    public Button startButton;
    public TextMeshProUGUI pointsLabel;
    public TextMeshProUGUI healthLabel;
    public static int points = 0;
    public int health;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement script = player.GetComponent<PlayerMovement>();
        if (isGameActive == false)
        {
            Cursor.lockState = CursorLockMode.None;
            //Fixed bug of when game ended label didn't update to zero quick enough
            if(script.health/2 < 13)
            {
                healthLabel.text = "Health : 0";
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            pointsLabel.text = "Points : " + points;
            healthLabel.text = "Health : " + script.health / 2;

            if (script.hasHealthPowerup)
            {
                healthLabel.text = "Health : Immortal";
            }
        }
    }

    public void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        points = 0;
        isGameActive = true;
        startButton.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
    }
}
