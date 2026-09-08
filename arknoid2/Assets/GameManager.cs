using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
        else
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void StartNewGame()
    {
        score = 0;
        lives = 3;

        SceneManager.LoadScene("Level1");
    }

    public void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Pontos: " + score;

        if (livesText != null)
            livesText.text = "Vidas: " + lives;
    }
}