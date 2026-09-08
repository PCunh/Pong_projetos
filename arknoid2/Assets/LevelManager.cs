using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int quantidadeDeBlocos;

    private void Start()
    {
        GameObject[] blocos = GameObject.FindGameObjectsWithTag("Brick");

        quantidadeDeBlocos = blocos.Length;

        Debug.Log("Blocos encontrados: " + quantidadeDeBlocos);
    }

    public void BlocoDestruido()
    {
        quantidadeDeBlocos--;

        Debug.Log("Blocos restantes: " + quantidadeDeBlocos);

        if (quantidadeDeBlocos <= 0)
        {
            ProximoNivel();
        }
    }

    private void ProximoNivel()
    {
        Scene cenaAtual = SceneManager.GetActiveScene();

        if (cenaAtual.name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (cenaAtual.name == "Level2")
        {
            SceneManager.LoadScene("Vitoria");
        }
    }
}