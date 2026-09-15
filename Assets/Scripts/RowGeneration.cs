using TMPro;
using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    public TMP_InputField numberInputField;
    public float squareSize = 1f;
    public float gapBetweenSquares = 0.5f;
    public Color squareColor = Color.green;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void DrawSquares()
    {
        //Safely convert text to number
        if (numberInputField == null) return;

		//https://www.dotnetperls.com/parse
		if (int.TryParse(numberInputField.text, out int count))
        {
			//https://www.w3schools.com/cs/cs_for_loop.php
			//Loop based on the number of squares (number) typed into the field
			for (int i = 0; i < count; i++)
            {
                float startX = i * (squareSize + gapBetweenSquares);

                //Similiar method to Task 1
				//4 Corners
				Vector3 bottomLeft = new Vector3(startX, 0, 0);
				Vector3 topLeft = new Vector3(startX, squareSize, 0);
				Vector3 topRight = new Vector3(startX + squareSize, squareSize, 0);
				Vector3 bottomRight = new Vector3(startX + squareSize, 0, 0);

				//4 Lines 
				Debug.DrawLine(bottomLeft, topLeft, squareColor);
				Debug.DrawLine(topLeft, topRight, squareColor);
				Debug.DrawLine(topRight, bottomRight, squareColor);
				Debug.DrawLine(bottomRight, bottomLeft, squareColor);
			}
        }
	}
}
