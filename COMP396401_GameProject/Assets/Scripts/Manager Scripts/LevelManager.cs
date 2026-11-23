using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Timer")]
    public float gameTime = 180f;
    public TMP_Text timerText;

    [Header("Castle")]
    [SerializeField] private GameObject castle;
    public int castleMaxHealth = 150;
    public int castleHealth = 100;
    public Scrollbar castleHealthBar;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public TMP_Text winnerText;
    private bool gameOver = false;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        UpdateCastleHealthBar();
    }

    //Timer and Player 1 Win
    void Update()
    {
        if (gameOver) return;

        //Timer countdown
        gameTime -= Time.deltaTime;

        //Update Timer
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);

        //Display Timer
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //Player 1 Win Condition
        if (gameTime <= 0)
        {
            PlayerOneWins();
        }
    }

    //Castle Health and Player 2 Win
    public void DamageCastle(int damage)
    {
        if (gameOver) return;

        castleHealth -= damage;
        castleHealth = Mathf.Max(castleHealth, 0);

        UpdateCastleHealthBar();

        //Player 2 Win Condition
        if (castleHealth <= 0)
        {
            PlayerTwoWins();
        }
    }

    //Player 1 Win
    public void PlayerOneWins()
    {
        GameOverScreen("Player 1 Wins!");
    }

    //Player 2 Win
    public void PlayerTwoWins()
    {
        GameOverScreen("Player 2 Wins!");
    }

    //Game Over
    public void GameOverScreen(string winner)
    {
        gameOver = true;

        gameOverPanel.SetActive(true);
        winnerText.text = winner;

        Time.timeScale = 0f;
    }

    //Restart Game Level
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameLvl1");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Entered MainMenu");
    }

    public bool IsCastle(Collider other)
    {
        return other.transform == castle.transform || other.transform.IsChildOf(castle.transform);
    }

    public void UpdateCastleHealthBar()
    {
        castleHealthBar.size = (float)castleHealth / castleMaxHealth;
    }

}
