using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    private Rigidbody2D rb;
    private bool launched = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!launched && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            LancarBola();
        }

        if (launched)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }

    private void LancarBola()
    {
        launched = true;

        Vector2 direcao = new Vector2(
            Random.Range(-0.7f, 0.7f),
            1f
        ).normalized;

        rb.linearVelocity = direcao * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Brick brick = collision.gameObject.GetComponent<Brick>();

            if (brick != null)
            {
                brick.Destruir();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoseLife();
            }
        }
    }
}