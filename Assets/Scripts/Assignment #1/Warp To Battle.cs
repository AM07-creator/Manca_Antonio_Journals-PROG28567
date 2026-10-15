using UnityEngine;
using UnityEngine.InputSystem;

public class WarpToBattle : MonoBehaviour
{
    //A float for the specified range from the enemy the player can warp to
    public float WarpDistance = 2.5f;
    //A transform of the enemy
    public Transform enemyTransform;
    // Update is called once per frame
    void Update()
    {
        WarpToFight();
    }
	public void WarpToFight()
	{
        //If the qKey is pressed this frame:
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            //Make a new vector3 equal a random point on a unit circle that is normalized
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            //Make a new Vector3 equal a vector3 that gathers a random x and y point to spawn the player ship, scaled by the specific range they must be from the enemy
            Vector3 randomTeleportOnMaxDistance = new Vector3(randomDirection.x, randomDirection.y, 0) * WarpDistance;
            //This game object's transform position equals the enemy's transform position plus the random teleport location around the specified range of the enemy
            transform.position = enemyTransform.position + randomTeleportOnMaxDistance;
        }
	}
}
