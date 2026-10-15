using UnityEngine;
using UnityEngine.InputSystem;

public class WarpToBattle : MonoBehaviour
{
    public float WarpDistance = 2.5f;
    public Transform enemyTransform;
    // Update is called once per frame
    void Update()
    {
        WarpToFight();
    }
	public void WarpToFight()
	{
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized;

            Vector3 randomTeleportOnMaxDistance = new Vector3(randomDirection.x, randomDirection.y, 0) * WarpDistance;

            transform.position = enemyTransform.position + randomTeleportOnMaxDistance;
        }
	}
}
