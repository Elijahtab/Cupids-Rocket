using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float minX, maxX, minY, maxY;
    public int health = 5;

    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    [SerializeField] public float bulletTimer;

    public BulletBar bulletBar;
    public HealthBar healthBar;

    public PauseScript pauseScript;
    public GameObject gameOverPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Camera mainCamera = Camera.main;
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        minX = -screenBounds.x + transform.localScale.x / 2;
        maxX = screenBounds.x - transform.localScale.x / 2;
        minY = -screenBounds.y + transform.localScale.y / 2;
        maxY = screenBounds.y - transform.localScale.y / 2;

        pauseScript = GameObject.Find("GameController").GetComponent<PauseScript>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        // Clamp the position to the screen bounds
        Vector3 newPosition = transform.position + (Vector3)movement * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        transform.position = newPosition;

        rb.velocity = Vector2.zero;

        // Point at pointer
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        transform.up = direction;

        // Bullet velocity
        if ((Input.GetMouseButtonDown(0)) && ( bulletTimer <= 0f))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = direction.normalized * bulletSpeed;
            bulletTimer = 1f;
        }
        if (bulletTimer > 0f)
        {
            bulletTimer -= Time.deltaTime;
        }
        bulletBar.SetBulletBar(bulletTimer);


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other GameObject is an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            healthBar.SetHealthBar(health);
            Destroy(other.gameObject);
            if(health <= 0)
            {
                pauseScript.PauseGame();
                GameObject gameOver = Instantiate(gameOverPrefab);
            }
        }
    }
}