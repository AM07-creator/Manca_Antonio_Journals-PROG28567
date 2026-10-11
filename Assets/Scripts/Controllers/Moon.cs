using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
	public float radius = 1f;
	public float speed = 2.5f;
    float angle;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, speed, planetTransform);
    }
    void OrbitalMotion(float radius, float speed, Transform target)
    {
		if (target == null) return;

		// add the angle to the speed multiplied by time.deltaTime calculation
		angle += speed * Time.deltaTime;

		// Calculate the x and y position of the points where the moon will be
		float x = target.position.x + Mathf.Cos(angle) * radius;
		float y = target.position.y + Mathf.Sin(angle) * radius;

		// Make the moon orbit
		transform.position = new Vector3(x, y, transform.position.z);
	}
}
