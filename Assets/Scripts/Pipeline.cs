using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public float t = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Convert the mouse position into a Vector3 variable
        Vector3 mousePos = Mouse.current.position.ReadValue();

        //If its been 0.1 seconds since the mouse was pressed, start drawing a line from the last 0.1 seconds to your current position every 0.1 seconds
        t = Time.deltaTime;
        if (t > 0.1f)
        {
            Debug.DrawLine(mousePos, Vector3.zero); //Somehow, pythagorean's theorem can be used here to tell where the mouse was 0.1 seconds ago, which if I had enough time I could could the distance between the current and past points of the line being drawn
            //The origin point is just a placeholder to stop an error from occurring
        }
    }
}
