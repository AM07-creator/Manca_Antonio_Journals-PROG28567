using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	public Transform enemyTransform;
	public GameObject bombPrefab;
	public List<Transform> asteroidTransforms;
	public Transform player;
	public Transform enemy;
	public float speed = 1f;
	float time;
	float lerpLength;

	private void Start()
	{
		Debug.Log(Normalizer(new Vector2(4, 4)));
		Debug.Log(Normalizer(new Vector2(-3, 2)));
		Debug.Log(Normalizer(new Vector2(1.5f, -3.5f)));

		time = Time.time;
		lerpLength = Vector3.Distance(player.position, enemy.position);
	}

	// Update is called once per frame
	void Update()
	{
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

		//Task 3
		float distanceCovered = (Time.time - time) * speed;
		float fractionOfWarp = distanceCovered / lerpLength;
		transform.position = Vector3.Lerp(player.position, enemy.position, fractionOfWarp);

		//Task 4
		//DetectAsteroids();
	}
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
	Vector2 Normalizer(Vector2 normalized)
	{
		float magnitude = normalized.magnitude;
		Vector2 outVector = new Vector2(normalized.x / magnitude, normalized.y / magnitude);

		return normalized;
	}
}