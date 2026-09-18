using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;

    private TMP_Text scoreText;
    private TMP_Text livesText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ProcurarTextos();
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ProcurarTextos();
        UpdateUI();
    }

    private void ProcurarTextos()
    {
        GameObject scoreObject = GameObject.Find("ScoreText");
        GameObject livesObject = GameObject.Find("LivesText");

        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TMP_Text>();
        }

        if (livesObject != null)
        {
            livesText = livesObject.GetComponent<TMP_Text>();
        }
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
            SceneManager.LoadScene("derrota");
        }
        else
        {
            Scene cenaAtual = SceneManager.GetActiveScene();
            SceneManager.LoadScene(cenaAtual.name);
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
        {
            scoreText.text = "Pontos: " + score;
        }

        if (livesText != null)
        {
            livesText.text = "Vidas: " + lives;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}