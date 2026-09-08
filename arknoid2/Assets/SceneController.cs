using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void IniciarJogo()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartNewGame();
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void IrParaVitoria()
    {
        SceneManager.LoadScene("Vitoria");
    }

    public void IrParaDerrota()
    {
        SceneManager.LoadScene("Derrota");
    }

    public void ReiniciarJogo()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartNewGame();
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void VoltarApresentacao()
    {
        SceneManager.LoadScene("Apresentacao");
    }
}