using UnityEngine;
using UnityEngine.InputSystem;

public class CannonballController : MonoBehaviour
{
    public GameObject leftCannon;
    public GameObject rightCannon;
	// Start is called before the first frame update
	void Start()
    {
        Destroy(gameObject, 3);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Pirate Ship Target"))
        {
            ScoreboardController.Instance.Score += 1;
        }

        Destroy(gameObject);
    }
}
