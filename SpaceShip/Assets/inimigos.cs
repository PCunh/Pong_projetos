using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float velocidade = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}