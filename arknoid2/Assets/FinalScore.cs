using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text =
                "Pontuação final: " +
                GameManager.Instance.score;
        }
    }
}