using UnityEngine;

public class PlayerControll : MonoBehaviour

{
    private Rigidbody2D rb2d;
    public AudioSource source;
    public float speed = 13f;

    [Header("Limites")]
    public float minX = -2.2f;
    public float maxX = 2.2f;
    public float minY = -4.2f;
    public float maxY = -0.3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 destino = new Vector2(
            Mathf.Clamp(mouse.x, minX, maxX),
            Mathf.Clamp(mouse.y, minY, maxY)
        );

        rb2d.MovePosition(Vector2.Lerp(rb2d.position, destino, speed * Time.fixedDeltaTime));

    }

    void OnCollisionEnter2D (Collision2D collision) 
    {
        if(source != null)
            source.Play();
    }
}
