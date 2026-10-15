using UnityEngine;

public class FaceOff : MonoBehaviour
{
	[Tooltip("Measured in degrees per second.")]
	//A float for the speed the ships rotate (meant to be so high it looks instantaneous)
	//And another one for the distance the hips must be within each other to face off
	public float angularSpeed = 1000;
	public float facingRadius = 5;
	//A transform for the target game object to face. For each ship in the unity inspector, it'll be the opposing team's ship as the target
	public Transform target;
	// Update is called once per frame
	void Update()
	{
		//Local Vector3 is equal to the position of the target transform variable, minus this game object's transform position. This is than normalized to a value of 1
		Vector3 directionToTargets = (target.position - transform.position).normalized;
		//Local float deltaAngle is equal to the ComputeShortestAngle method, returning a transform's top and the direction to target Vector3
		float deltaAngle = ComputeShortestAngle(transform.up, directionToTargets);

		//Local float for the direction to rotate is equal to a math function of sign, returning a float value for the deltaAngle float
		float rotateDirection = Mathf.Sign(deltaAngle);
		//Local float angleStep is equal to the rotation speed float overtime (multiplied by time)
		float angleStep = angularSpeed * Time.deltaTime;

		//Local float faceRange is equal to a Vector3, tracking the distance between this game object and the targeted game object
		float faceRange = Vector3.Distance(transform.position, target.position);

		//If statement saying if the faceRange is less than or equal to the facing radius, cause the if statements within to trigger
		if (faceRange <= facingRadius)
		{
			//If the speed overtime is less than the absolute value of the shortest angle to compute, rotate the transform of this game object on it's z axis
			//multiplied by speed overtime. Otherwise, keep the rotation at the static, absolute value from deltaAngle
			if (angleStep < Mathf.Abs(deltaAngle))
			{
				transform.Rotate(0, 0, rotateDirection * angularSpeed * Time.deltaTime);
			}
			else
			{
				transform.Rotate(0, 0, deltaAngle);
			}
		}
	}
	//Method of type float called ComputeShortestAngle, returns 2 vector3s
	private float ComputeShortestAngle(Vector3 a, Vector3 b)
	{
		//2 floats for the x and y coordinates of two different points. A math function of inverse tangent finds the x and y values for both angle a and b,
		//then multiplies them by a math function that converts the angles from degrees to radians
		float angleA = Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg;
		float angleB = Mathf.Atan2(b.y, b.x) * Mathf.Rad2Deg;

		//At the end of the method, return a value of math function of DeltaAngle, finding the difference between angle a and b
		return Mathf.DeltaAngle(angleA, angleB);
	}
}
