using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.01f;
    Vector2 movingDirection = Vector2.zero;
    FacingDirection lastFacingDirection = FacingDirection.right;
    Rigidbody2D rb;
    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
        //Grab same rigidbody atatched to this game object
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

		Vector2 playerInput = new Vector2();

        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        //Movement method is my own code, taken from Programming 2. Readily available method of adding input
		bool isLeftHeld = Keyboard.current.leftArrowKey.isPressed;
		if (isLeftHeld == true)
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
		bool isRightHeld = Keyboard.current.rightArrowKey.isPressed;
		if (isRightHeld == true)
		{
			transform.position += transform.right * speed * Time.deltaTime;
		}
	}

    public bool IsWalking()
    {
        return false;

		bool isLeftHeld = Keyboard.current.leftArrowKey.isPressed;
		bool isRightHeld = Keyboard.current.rightArrowKey.isPressed;

        return isLeftHeld != isRightHeld;

	}
    public bool IsGrounded()
    {
        //The absolute linearVelocity of the vertical axis. If the vertical speed is less than a number that's basically 0, then the player is considered to be grounded. Otherwise, it's false and the player is falling through the air
		return Mathf.Abs(rb.linearVelocity.y) < 0.01f;
	}

    public FacingDirection GetFacingDirection()
    {
		bool isLeftHeld = Keyboard.current.leftArrowKey.isPressed;
		bool isRightHeld = Keyboard.current.rightArrowKey.isPressed;

		if (isLeftHeld && !isRightHeld)
		{
			lastFacingDirection = FacingDirection.left;
		}
		else if (isRightHeld && !isLeftHeld)
		{
			lastFacingDirection = FacingDirection.right;
		}

		return lastFacingDirection;
	}
}
