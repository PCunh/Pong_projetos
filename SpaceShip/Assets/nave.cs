using UnityEngine;
using UnityEngine.InputSystem;

public class Nave : MonoBehaviour
{
    public float velocidade = 5f;

    public GameObject tiroPrefab;
    public Transform pontoDisparo;

    void Update()
    {
        Movimentar();

        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Atirar();
        }
    }

    void Movimentar()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current == null)
            return;

        if (Keyboard.current.wKey.isPressed ||
            Keyboard.current.upArrowKey.isPressed)
            vertical = 1f;

        if (Keyboard.current.sKey.isPressed ||
            Keyboard.current.downArrowKey.isPressed)
            vertical = -1f;

        if (Keyboard.current.aKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.dKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1f;

        Vector3 movimento = new Vector3(horizontal, vertical, 0f);

        transform.position += movimento.normalized
                              * velocidade
                              * Time.deltaTime;
    }

    void Atirar()
    {
        if (tiroPrefab != null && pontoDisparo != null)
        {
            Instantiate(
                tiroPrefab,
                pontoDisparo.position,
                Quaternion.identity
            );
        }
    }
}