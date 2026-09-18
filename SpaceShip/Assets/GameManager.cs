using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pontuacao = 0;

    public TMP_Text textoPontuacao;

    public float tempoLento = 0.4f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdicionarPontos(int pontos)
    {
        pontuacao += pontos;

        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontos: " + pontuacao;
        }

        if (pontuacao >= 30)
        {
            Time.timeScale = tempoLento;
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}