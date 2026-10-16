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

    void Start()
    {
        AtualizarPontuacao();
    }

    public void AdicionarPontos(int pontos)
    {
        pontuacao += pontos;
        AtualizarPontuacao();

        if (pontuacao >= 30)
        {
            Time.timeScale = tempoLento;
        }
    }

    void AtualizarPontuacao()
    {
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontos: " + pontuacao;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Time.timeScale = 1f;
        }
    }
}