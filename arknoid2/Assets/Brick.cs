using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitsToBreak = 1;

    private int currentHits = 0;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Destruir()
    {
        currentHits++;

        // Ainda precisa de mais pancadas
        if (currentHits < hitsToBreak)
        {
            AtualizarAparencia();
            return;
        }

        // O bloco foi destruído
        GameManager gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager != null)
        {
            gameManager.AddScore(10);
        }

        Destroy(gameObject);
    }

    private void AtualizarAparencia()
    {
        if (spriteRenderer == null)
            return;

        float progresso = (float)currentHits / hitsToBreak;

        Color novaCor = Color.Lerp(
            Color.white,
            new Color(0.25f, 0.25f, 0.25f),
            progresso
        );

        spriteRenderer.color = novaCor;
    }
}