using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public float squareSize = 1.0f;
    public Color squareColor = Color.white;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //If M1 is pressed this frame, spawn a square at mouse Position
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Track mouse position in world space
            //Other Method     Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = GetMouseWorldPos();

			//Call function to spawn the sqaure at the mouse position
			DrawSquare(mouseWorldPos, squareSize);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        //Pixel coordinates of mouse
        Vector3 mouseScreenPos = Input.mousePosition;

		//Camera position in pixels
		return Camera.main.ScreenToWorldPoint(mouseScreenPos);
	}

    void DrawSquare(Vector3 center, float sqaureSize) //Declare a Vector3 for the center so we can subtract and add on both axis to determine the corners, then to determine the lines. Don't touch the Z
    {
        //Corners
        Vector3 topLeft = new Vector3(center.x - 0.5f, center.y + 0.5f, center.z);
		Vector3 topRight = new Vector3(center.x + 0.5f, center.y + 0.5f, center.z);
		Vector3 bottomLeft = new Vector3(center.x - 0.5f, center.y - 0.5f, center.z);
		Vector3 bottomRight = new Vector3(center.x + 0.5f, center.y - 0.5f, center.z);

        //Lines between Corners
        Debug.DrawLine(topLeft, topRight, squareColor, squareSize);
		Debug.DrawLine(topRight, bottomRight, squareColor, squareSize);
		Debug.DrawLine(bottomRight, bottomLeft, squareColor, squareSize);
		Debug.DrawLine(bottomLeft, topLeft, squareColor, squareSize);
	}
}
