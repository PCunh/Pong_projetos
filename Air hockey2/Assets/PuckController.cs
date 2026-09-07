using UnityEngine;

public class PuckController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float initialForce = 8f;
    public float minSpeed = 4f;
    public float maxSpeed = 12f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke(nameof(GoPuck), 1f);
    }

    void FixedUpdate()
    {
        float speed = rb2d.linearVelocity.magnitude;

        if (speed > 0.1f && speed < minSpeed)
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * minSpeed;

        if (speed > maxSpeed)
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * maxSpeed;
    }

    void GoPuck()
    {
        Vector2 dir = Random.insideUnitCircle.normalized;

        if (Mathf.Abs(dir.y) < 0.4f)
            dir.y = Mathf.Sign(dir.y == 0 ? 1 : dir.y) * 0.4f;

        rb2d.linearVelocity = Vector2.zero;
        rb2d.AddForce(dir * initialForce, ForceMode2D.Impulse);
    }

    public void ResetPuck()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    public void RestartGame()
    {
        ResetPuck();
        Invoke(nameof(GoPuck), 1f);
    }
}