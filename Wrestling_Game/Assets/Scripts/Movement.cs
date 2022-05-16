using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public Rigidbody2D rb { get; private set; }  
    public Collider2D col { get; private set; }
    public SpriteRenderer sp { get; private set; }
    public Vector3 startingPosition { get; private set; }   // ªì©l¦ì¸m


    // ==========================================================

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sp = GetComponent<SpriteRenderer>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    private void FixedUpdate()
    {
        Debug.Log("inloop");
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
            sp.flipX = true;
            if (col.offset.x < 0) col.offset = new Vector2(-col.offset.x, col.offset.y);
        }
            
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector2.left);
            sp.flipX = false;
            if (col.offset.x > 0) col.offset = new Vector2(-col.offset.x, col.offset.y);
        }

        if (Input.GetKey(KeyCode.W)) Move(Vector2.up);
        if (Input.GetKey(KeyCode.S)) Move(Vector2.down);
    }

    // =================================================================
    private void ResetState()
    {
        transform.position = startingPosition;
    }

    private void Move( Vector2 direction)
    {
        Vector2 position = transform.position;
        Vector2 translate = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(position + translate);
    }

}
