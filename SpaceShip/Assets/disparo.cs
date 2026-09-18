using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            if (GameManager.Instance != null)
            {
                GameManager.Instance.AdicionarPontos(10);
            }
        }
    }
}