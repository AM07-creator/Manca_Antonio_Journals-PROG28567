using System;
using UnityEngine;

public class Journal5 : MonoBehaviour
{
    public Rigidbody2D rigBod;
	public PhysicsMaterial2D physBod;
	public PhysicsMaterialCombine2D combineBodA;
	public PhysicsMaterialCombine2D combineBodB;
	float a = 10f;
	float b = 0f;
	public Rigidbody2D simBod;
	public Vector3 windy;
	public float gustPower = 10f;
	//public bool IsTouching(ContactFilter2D colBod);


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
       
	}

	// Update is called once per frame
	void Update()
    {
		#region C1
		//Continuous detection of colliders in game while moving
		rigBod = GetComponent<Rigidbody2D>();
		rigBod.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

		//Discrete detection track colliders in their new position while moving
		rigBod = GetComponent<Rigidbody2D>();
		rigBod.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
		#endregion
		#region C2
		physBod = GetComponent<PhysicsMaterial2D>();
		physBod.bounceCombine = PhysicsMaterialCombine2D.Mean;
		#endregion

		#region C3
		simBod.simulated = true;
		simBod.AddForce(windy.normalized * gustPower);
		#endregion

		#region C4
		
		#endregion
	}
}
