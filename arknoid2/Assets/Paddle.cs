using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float limiteX = 7.5f;

    private void Update()
    {
        float movimento = 0f;

        if (Keyboard.current.leftArrowKey.isPressed ||
            Keyboard.current.aKey.isPressed)
        {
            movimento = -1f;
        }

        if (Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.dKey.isPressed)
        {
            movimento = 1f;
        }

        Vector3 novaPosicao = transform.position;

        novaPosicao.x += movimento * speed * Time.deltaTime;

        novaPosicao.x = Mathf.Clamp(
            novaPosicao.x,
            -limiteX,
            limiteX
        );

        transform.position = novaPosicao;
    }
}