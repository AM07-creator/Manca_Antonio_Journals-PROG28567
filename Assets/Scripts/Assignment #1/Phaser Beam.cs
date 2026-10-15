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
		float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);


		if (enemyTransform != null)
		{
			if (distanceToEnemy <= radius)
			{
				Debug.DrawLine(transform.position, enemyTransform.position, Color.cyan);
			}
		}
	}
}
