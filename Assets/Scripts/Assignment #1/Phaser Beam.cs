using System.Collections.Generic;
using UnityEngine;

public class PhaserBeam : MonoBehaviour
{
	//1 Transform for the enemy
	public Transform enemyTransform;
	//A float for the radius the player must be within the enemy to draw a phaser
	public float radius = 2.5f;

    // Update is called once per frame
    void Update()
    {
		Phaser();
    }
	void Phaser()
	{
		//Local float is equal to a Vector3 that tracks distance between player and enemy
		float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);

		//Ensure the enemy transform isn't null to prevent errors
		if (enemyTransform != null)
		{
			//If the distance between the player and enemy is less than or equal to the radius float, draw a cyan colored line from the player to the enemy transform
			if (distanceToEnemy <= radius)
			{
				Debug.DrawLine(transform.position, enemyTransform.position, Color.cyan);
			}
		}
	}
}
