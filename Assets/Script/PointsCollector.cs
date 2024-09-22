using UnityEngine;

public class PointsCollector : MonoBehaviour
{
    // Initialize the Script.
    [SerializeField] private UserInterfaceManager uiManager;

    void OnCollisionEnter(Collision collision)
    {
        // Check the collision of object with player who are tagged as Point.
        if(collision.gameObject.tag == "Point"){
            Destroy(collision.gameObject);
            uiManager.points++;
        }

        if(collision.gameObject.tag == "Boundary"){
            uiManager.isGameOver = true;
        }
    }
}
