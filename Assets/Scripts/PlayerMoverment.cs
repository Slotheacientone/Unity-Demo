using UnityEngine;

/*
 * Control player movement and animation.
 */
public class PlayerMoverment : MonoBehaviour
{
    // Moving speed
    [SerializeField] private float speed = 10;

    //jumpHeight
    [SerializeField] private float jumpHeight = 30;

    // Active more nature movement
    [SerializeField] private bool natureMovement = false;

    // Rigid body object
    private Rigidbody2D body;

    // Animator object
    private Animator animator;

    // Character's state
    private CharacterState characterState;

    /*
     * Run at the start.
     */
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterState = new CharacterState();
    }

    /*
     * Run at every frame.
     */
    private void Update()
    {
        // Get player input
        characterState.InputHorizontal = Input.GetAxis("Horizontal");
        characterState.InputJump = Input.GetKeyDown(KeyCode.Space);
 
        if (natureMovement)
        {
            // TODO: Implement more nature movement.
            MoveUsingForce();
        }
        else
        {
            MoveUsingVelocity();
        }
        // Jumping
        Jump();

        // Controll animation
        AnimationControll();
    }

    /*
     * Move character by apply velocity.
     */
    private void MoveUsingVelocity()
    {
        // Moving left and right
        body.velocity = new Vector2(characterState.InputHorizontal * speed, body.velocity.y);

        // Flipping character spike denpend on moving direction
        Flip();

    }

    /*
     * Jumping.
     */
    private void Jump()
    {
        // Jumping
        if (characterState.InputJump && characterState.IsGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            characterState.IsGrounded = false;

        }
    }

    /*
     * Detect character's collision.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            characterState.IsGrounded = true;
        }
    }

    /*
     * Flipping character spike denpend on moving direction.
     */
    private void Flip()
    {
        if (characterState.InputHorizontal > 0.01f)
        {
            // Flip sprite to the right
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (characterState.InputHorizontal < -0.01f)
        {
            // Flip sprite to the left
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    /*
     * Control animation.
     */
    private void AnimationControll()
    {
        // Start run animation if inputHorizontal != 0
        animator.SetBool("isRunning", characterState.InputHorizontal != 0);
        //
        animator.SetBool("isGrounded", characterState.IsGrounded);
    }

    /*
     * TODO: Implement more nature movement.
     */
    private void MoveUsingForce()
    {
    }
}