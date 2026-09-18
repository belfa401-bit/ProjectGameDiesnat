using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    public Rigidbody2D rb;              // Rigidbody Bombi
    public Transform groundCheck;       // Empty object di bawah kaki
    public float checkRadius = 0.3f;    // Radius cek tanah
    public LayerMask groundLayer;       // Layer tanah

    private bool isGrounded;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // cek tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // update parameter animator
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("xSpeed", Mathf.Abs(rb.linearVelocity.x));

        // Debug untuk cek nilai
        Debug.Log("isGrounded: " + isGrounded + " | xSpeed: " + Mathf.Abs(rb.linearVelocity.x));

        // TES PAKSA ANIMASI
        if (Input.GetKeyDown(KeyCode.L))
            anim.Play("Bombi_Lari");   // paksa mainkan animasi lari

        if (Input.GetKeyDown(KeyCode.J))
            anim.Play("Bombi_Lompat"); // paksa mainkan animasi lompat
        

        if (Input.GetKeyDown(KeyCode.L))
        anim.Play("Bombi_Lari");

        if (Input.GetKeyDown(KeyCode.J))
        anim.Play("Bombi_Lompat");

    }

}
