using UnityEngine;
using UnityEngine.InputSystem;

public class Nave : MonoBehaviour
{
    public GameObject tiroPrefab;
    public Transform pontoDisparo;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Atirar();
        }
    }

    void Atirar()
    {
        GameObject novoTiro = Instantiate(
            tiroPrefab,
            pontoDisparo.position,
            Quaternion.identity
        );

        novoTiro.transform.position = pontoDisparo.position;
    }
}