using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.3f;
    public LayerMask groundLayer;

    [Header("Sprites")]
    public Sprite idleSprite;
    public Sprite walkSprite;
    public Sprite jumpSprite;

    private SpriteRenderer sr;
    private bool isGrounded;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // cek tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // cek input horizontal
        float horizontal = Input.GetAxis("Horizontal");

        // kondisi sprite
        if (!isGrounded)
        {
            sr.sprite = jumpSprite; // kalau di udara → sprite lompat
        }
        else
        {
            if (Mathf.Abs(horizontal) > 0.1f)
                sr.sprite = walkSprite; // kalau jalan → sprite jalan
            else
                sr.sprite = idleSprite; // kalau diam → sprite idle
        }
    }
}
