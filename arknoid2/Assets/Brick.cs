using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int pontos = 10;

    private bool destruido = false;

    public void Destruir()
    {
        if (destruido)
            return;

        destruido = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(pontos);
        }

        LevelManager levelManager = FindFirstObjectByType<LevelManager>();

        if (levelManager != null)
        {
            levelManager.BlocoDestruido();
        }

        Destroy(gameObject);
    }
}