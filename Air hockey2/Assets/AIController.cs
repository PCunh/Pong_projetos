using UnityEngine;

public class AIController : MonoBehaviour
{
    private Vector2 homePosition;
    private Rigidbody2D rb2d;

    public float speed = 8f;
    public Transform puck;

    public float minX = -3.5f;
    public float maxX = 3.5f;
    public float minY = 0.4f;
    public float maxY = 7f;

    // Start is called once before the first execution of Update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        homePosition = rb2d.position;

        if (puck == null)
        puck = GameObject.FindGameObjectWithTag("Puck").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 target;

        if (puck.position.y > -0.5f)
        {
            target = new Vector2(puck.position.x, puck.position.y - 0.6f);
        }
        else
        {
            target = homePosition;
        }

        target.x = Mathf.Clamp(target.x, minX, maxX);
        target.y = Mathf.Clamp(target.y, minY, maxY);

        rb2d.MovePosition(Vector2.Lerp(rb2d.position, target, speed * Time.fixedDeltaTime));
    }
}

    
