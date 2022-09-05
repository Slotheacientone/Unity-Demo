/*
 * Character's state.
 */
internal class CharacterState
{
    // whether character is grounded or not
    private bool isGrounded = true;

    // Player input in horizontal.
    private float inputHorizontal = 0.0f;

    // Player input for jumping
    private bool inputJump = false;

    // Getter and setter
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public float InputHorizontal { get => inputHorizontal; set => inputHorizontal = value; }
    public bool InputJump { get => inputJump; set => inputJump = value; }
}