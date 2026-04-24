using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private int playerIndex;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private PlayerAttack playerAttack;

    private bool isGrounded;
    private float lastDirection = 1f;

    private KeyCode left;
    private KeyCode right;
    private KeyCode jump;
    private KeyCode attack;
    private KeyCode ability;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
        SetupKeys();
    }

    public void SetPlayerIndex(int index)
    {
        playerIndex = index;
        SetupKeys();
    }

    private void SetupKeys()
    {
        if (playerIndex == 0)
        {
            left = KeyCode.A;
            right = KeyCode.D;
            jump = KeyCode.W;
            attack = KeyCode.Space;
            ability = KeyCode.LeftShift;
        }
        else if (playerIndex == 1)
        {
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            jump = KeyCode.UpArrow;
            attack = KeyCode.RightControl;
            ability = KeyCode.RightShift;
        }
        else if (playerIndex == 2)
        {
            left = KeyCode.J;
            right = KeyCode.L;
            jump = KeyCode.I;
            attack = KeyCode.U;
            ability = KeyCode.O;
        }
        else
        {
            left = KeyCode.Keypad4;
            right = KeyCode.Keypad6;
            jump = KeyCode.Keypad8;
            attack = KeyCode.Keypad0;
            ability = KeyCode.KeypadPeriod;
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(attack))
        {
            if (playerAttack != null)
                playerAttack.Shoot(lastDirection);
        }

        if (Input.GetKeyDown(ability))
        {
            Debug.Log("Player " + (playerIndex + 1) + " ability");
        }
    }

    private void FixedUpdate()
    {
        float x = 0f;

        if (Input.GetKey(left)) x = -1f;
        if (Input.GetKey(right)) x = 1f;

        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        if (x != 0)
        {
            lastDirection = Mathf.Sign(x);
            transform.localScale = new Vector3(lastDirection, 1f, 1f);
        }
    }
}