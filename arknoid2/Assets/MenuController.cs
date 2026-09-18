using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Jogar()
    {
        Debug.Log("Botão Jogar foi clicado!");

        SceneManager.LoadScene("Level1");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Introducao");
    }

    public void Sair()
    {
        Application.Quit();
    }
}