using UnityEngine;

public class PointsCollector : MonoBehaviour
{
    // Initialize the Script.
    [SerializeField] private UserInterfaceManager uiManager;

    void OnCollisionEnter(Collision collision)
    {
        // Check the collision of object with player who are tagged as Point.
        if(collision.gameObject.tag == "Point"){
            Debug.Log("Collided with: " + collision.gameObject.name);
            Destroy(collision.gameObject);
            uiManager.points++;
        }
    }
}
