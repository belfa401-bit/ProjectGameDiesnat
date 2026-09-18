using UnityEngine;

public class GroundCheckTest : MonoBehaviour
{
    public Transform groundCheck;     // drag empty object di bawah kaki Bombi
    public float checkRadius = 0.3f;  // lingkaran cek tanah
    public LayerMask groundLayer;     // pilih layer tanah

    private bool isGrounded;

    void Update()
    {
        // cek apakah Bombi kena tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded)
        {
            Debug.Log("Bombi grounded ✅");
        }
        else
        {
              Debug.Log("Bombi di udara ❌");
        }

        // test lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 10f);
            Debug.Log("Jump!");
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
