using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private Vector3 currentPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;

    int currentLine = 0;
    float timeOnCurrentLine = 0f;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation(); 
    }

    private void DrawConstellation()
    {
		//https://discussions.unity.com/t/how-can-i-animate-draw-a-line-renderer-over-a-given-period-of-time/689936
		//Ensure we have at least two points to draw a line between
		if (starTransforms == null || starTransforms.Count < 2) return;

        //Start the loop
        for (int i = 0; i < starTransforms.Count; i++)
        {
            //Null check for error prevention
            if (starTransforms[currentLine] != null && starTransforms[currentLine + 1] != null)
            {
                //Track time spent drwing current line overtime. Local float t is created to track the percentage until the drawing is complete by getting the time spent on the current drawing of a line divided by the total drawing time
                timeOnCurrentLine += Time.deltaTime;
                float t = Mathf.Clamp01(timeOnCurrentLine / drawingTime);

                Vector3 startPos = starTransforms[i].position;
                Vector3 targetEndPos = starTransforms[i + 1].position;

                //Draw the line from the current star to the next
                Debug.DrawLine(startPos, targetEndPos, Color.white);

                //Grow the line from it's start point to it's end point overtime
                Vector3 lerpEndPos = Vector3.Lerp(startPos, targetEndPos, t);

                //Draw the active line
                Debug.DrawLine(startPos, lerpEndPos, Color.white);
            }
        }

        currentLine = 0;
        timeOnCurrentLine = 0f;
    }
}
