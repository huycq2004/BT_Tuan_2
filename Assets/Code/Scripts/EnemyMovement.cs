using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.3f;          // Tốc độ di chuyển
    public float moveDistance = 3f;     // Khoảng cách di chuyển qua lại
    private Vector3 startPos;           // Vị trí ban đầu
    private bool movingRight = true;    // Hướng di chuyển
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= startPos.x + moveDistance)
                movingRight = false;

            // Đi sang phải thì lật X = true (ngược lại)
            spriteRenderer.flipX = true;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= startPos.x - moveDistance)
                movingRight = true;

            // Đi sang trái thì lật X = false (ngược lại)
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");
        }
    }
}
