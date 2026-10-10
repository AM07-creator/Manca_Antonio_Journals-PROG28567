using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	#region Week's 1-3
	public Transform enemyTransform;
	public GameObject bombPrefab;
	public List<Transform> asteroidTransforms;
	public Transform player;
	public float maxSpeed = 1f;
	float time;
	float lerpLength;
	public float accelerationTime = 1f;
	float acceleration;
	Vector3 velocity = Vector3.zero;
	Vector3 playerMovement;
	#endregion
	[Space]
	#region Week 4
	public List<float> angles = new ();
	int currentIndex = 0;
	public Vector3 startPoint;
	public float duration = 1f;
	float elapsedTime = 0f;
	public float radarRadius = 3f;
	public int shapeSidesCount = 8;

	#endregion

	private void Start()
	{
		#region Week 2
		Debug.Log(Normalizer(new Vector2(4, 4)));
		Debug.Log(Normalizer(new Vector2(-3, 2)));
		Debug.Log(Normalizer(new Vector2(1.5f, -3.5f)));

		//time = Time.time;
		//lerpLength = Vector3.Distance(player.position, enemyTransform.position);

		acceleration = maxSpeed / accelerationTime;

		#endregion
		#region Week 4 In-Class

		for (int i = 0; i < 10; i++)
		{
			float randomAngle = Random.Range(0f, 360f);
			angles.Add(randomAngle);
		}
		#endregion
	}

	// Update is called once per frame
	void Update()
	{
		#region Week's 1-3
		if (Keyboard.current.bKey.wasPressedThisFrame)
		{
			SpawnBombAtOffset(Vector3.up);
		}
		if (Keyboard.current.tKey.wasPressedThisFrame)
		{
			//Create 3 bombs, spaced 0.5 units apart on the y axis
			SpawnBombTrail(0.5f, 3);
		}
		if (Keyboard.current.rKey.wasPressedThisFrame)
		{
			//SpawnBombOnRandomCorner();
		}
		if (Keyboard.current.wKey.wasPressedThisFrame)
		{
			//WarpPLayer();
		}

		//Task 3 W2
		//float distanceCovered = (Time.time - time) * maxSpeed;
		//float fractionOfWarp = distanceCovered / lerpLength;
		//transform.position = Vector3.Lerp(player.position, enemyTransform.position, fractionOfWarp);

		//Task 4 W2
		//DetectAsteroids();
		PlayerMovement();
		#endregion
		#region Week 4 in-Class
		//Unit Circle Exercise Week 5
		elapsedTime += Time.deltaTime;
		if (elapsedTime > duration)
		{
			currentIndex = (currentIndex + 1) % angles.Count;
			elapsedTime = 0f;
		}

		if (Keyboard.current.spaceKey.wasPressedThisFrame)
		{
			currentIndex = (currentIndex + 1) % angles.Count;
		}

		float angle = angles[currentIndex];
		float angleInRads = angle * Mathf.Deg2Rad;

		float xPos = Mathf.Cos(angle);
		float yPos = Mathf.Sin(angle);

		Vector3 offset = new Vector3(xPos, yPos, 0f);

		Debug.DrawLine(startPoint, startPoint + offset);
		#endregion Week 4 In-Class

		#region Week 4 Journal
		EnemyRadar(radarRadius, shapeSidesCount);
		#endregion
	}
	#region Week's 1-3
	void SpawnBombAtOffset(Vector3 inOffset)
	{
		Instantiate(bombPrefab, transform.position + inOffset, Quaternion.identity);
	}
	void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
	{
		//-Transform.up to make bombs spawn behind
		Vector3 behindPlayer = -transform.up;

		for (int i = 1; i <= inNumberOfBombs; i++)
		{
			//https://discussions.unity.com/t/solved-unity-c-instantiate-multiple-prefabs-next-to-each-other-and-move-them-from-point1-to-point2/866630
			//The bombs will intsnatiate and space out downwards on the y axis
			Vector3 spawnPos = transform.position + (behindPlayer * (i * inBombSpacing));
			GameObject trailInstance = Instantiate(bombPrefab, spawnPos, Quaternion.identity);
		}
	}
	//Added my own return for a vector3 position around the player. This will be randomly picked between the 4 corners when the Rkey is pressed this frame
	void SpawnBombOnRandomCorner(Vector3 playerPos, float inDistance)
	{
		Vector3 topLeft = new Vector3(playerPos.x - 0.5f, playerPos.y + 0.5f, playerPos.z);
		Vector3 topRight = new Vector3(playerPos.x + 0.5f, playerPos.y + 0.5f, playerPos.z);
		Vector3 bottomLeft = new Vector3(playerPos.x - 0.5f, playerPos.y - 0.5f, playerPos.z);
		Vector3 bottomRight = new Vector3(playerPos.x + 0.5f, playerPos.y - 0.5f, playerPos.z);
	}
	//Pressing wKey will cause the player to warp a random distance towards the enemy using a lerp
	public void WarpPLayer(Transform target, float ratio)
	{
		//https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html

	}
	public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
	{
		
	}
	public void PlayerMovement()
	{
		if (Keyboard.current.leftArrowKey.isPressed)
		{
			velocity += Time.deltaTime * acceleration * Vector3.left;
		}
		if (Keyboard.current.rightArrowKey.isPressed)
		{
			velocity += Time.deltaTime * acceleration * Vector3.right;
		}
		if (Keyboard.current.upArrowKey.isPressed)
		{
			velocity += Time.deltaTime * acceleration * Vector3.up;
		}
		if (Keyboard.current.downArrowKey.isPressed)
		{
			velocity += Time.deltaTime * acceleration * Vector3.down;
		}
		if (velocity.magnitude > maxSpeed)
		{
			velocity = velocity.normalized * maxSpeed;
		}
		//velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

		transform.position += Time.deltaTime * velocity;
	}
	Vector2 Normalizer(Vector2 normalized)
	{
		float magnitude = normalized.magnitude;
		Vector2 outVector = new Vector2(normalized.x / magnitude, normalized.y / magnitude);

		return normalized;
	}
	#endregion
	#region Week 5 Journal
	void EnemyRadar(float radius, int circlePoints)
	{
		//Float variable equal to 360 degrees, divided by the number of sides in our circular drawn shape
		//To evenly space all angle changes across the 360 degrees
		float stepAngle = 360.0f / circlePoints;
		//Local List to store angle changes (points) of the circle
		List<Vector3> points = new();
		Color radarColor = Color.green;

		//If the enemy is within range of the player, turn the radar red
		if (enemyTransform != null)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);

			if (distanceToEnemy <= radius)
			{
				radarColor = Color.red;
			}
		}

		stepAngle *= Mathf.Deg2Rad;
		float currentAngle = stepAngle;

		//For loop that calculates the x and y position of points on the circle using inverse trig functions
		for (int i = 0; i < circlePoints; i++)
		{
			float xPos = Mathf.Cos(currentAngle) * radius;
			float yPos = Mathf.Sin(currentAngle) * radius;

			//Local Vector3 takes the x and y pos calculations above and makes them a new 2D point in the list
			Vector3 newPoint = new Vector2(xPos, yPos);
			points.Add(newPoint);

			currentAngle += stepAngle;
		}
		//For loop that draws the circle around the player's current position
		for (int i = 0; i < circlePoints - 1; i++)
		{
			Vector3 startPoint = transform.position + points[i];
			Vector3 endPoint = transform.position + points[i + 1];

			Debug.DrawLine(startPoint, endPoint, radarColor);

			if (i == circlePoints - 2)
			{
				startPoint = transform.position + points[i + 1];
				endPoint = transform.position + points[0];

				Debug.DrawLine(startPoint, endPoint, radarColor);
			}
		}
	}
	#endregion
}