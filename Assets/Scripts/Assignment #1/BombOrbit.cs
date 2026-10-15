using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BombOrbit : MonoBehaviour
{
    //Float for speed of rotation, one for the radius around the player the bomb orbits, and one for the angle the bomb is rotating at
    public float speed = 1.5f;
    public float radius = 1.5f;
    float angle;
    //Transform to get the player's current position and mnake the bomb rotate around it
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        BombRevolve(radius, speed, playerTransform);
    }
	void BombRevolve(float radius, float speed, Transform playerTransform)
	{
        //Null check for errors to prevent crashes
		if (playerTransform == null) return;

		//The angle of the orbiting bomb is now factoring the speed it moves at overtime, rather than over frames
		angle += speed * Time.deltaTime;

		//Calculate the x and y position of the points where the moon will be. The playerTransform position on both x and y axis.
        //Add a Math function of Cosine for X, returning us the angle and multiplying it by the radius from the player
        //Add a Math function of Sine for Y, returning us the angle and multiplying it by the radius from the player
		float x = playerTransform.position.x + Mathf.Cos(angle) * radius;
		float y = playerTransform.position.y + Mathf.Sin(angle) * radius;

		//The transform position of this game object is changed based on the x and y local variables.
        //The z axis remains locked to the game object's current transform position
		transform.position = new Vector3(x, y, transform.position.z);
	}
}
