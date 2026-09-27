using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float arrivalDistance = 1;
    public float maxFloatDistance = 1f;
    Vector3 moveDirection;
    Vector3 movementStartPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        //The game object will move ina  random direction
        moveDirection = Random.insideUnitCircle.normalized;
        
        //Move the object
        transform.position = (moveDirection * moveSpeed * Time.deltaTime);

        //Distance Travelled from start of random direction movement to current position
        arrivalDistance = Vector3.Distance(movementStartPosition, transform.position);

        if (arrivalDistance >= maxFloatDistance)
        {
			//The game object will move in a random direction in a 360 degree range, which is normalized
			moveDirection = Random.insideUnitCircle.normalized;

			//Move the object by an offset of our random direction variable, our speed float and overtime
			transform.position = (moveDirection * moveSpeed * Time.deltaTime);
		}
    }
}
