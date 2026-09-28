using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float accelerationTime = 1f;
	float acceleration;
	Vector3 velocity = Vector3.zero;
	float time;
	float lerpLength;
	public Transform player;
	public Transform enemyTransform;
	public float maxSpeed = 1f;
	GameObject playerObject;
	GameObject enemyObject;
	GameObject lerpEnemy;
	private void Start()
	{
		time = Time.time;
		lerpLength = Vector3.Distance(player.position, enemyTransform.position * time);
		acceleration = maxSpeed / accelerationTime;
	}
	private void Update()
    {
		EnemyMovement();
    }
    public void EnemyMovement()
    {
		velocity += Time.deltaTime * acceleration * transform.position;

		if (velocity.magnitude > maxSpeed)
		{
			velocity = velocity.normalized * maxSpeed;
		}

		transform.position += Time.deltaTime * velocity;

		lerpEnemy.transform.position = Vector3.Lerp(playerObject.transform.position, enemyObject.transform.position, maxSpeed);
	}
}
