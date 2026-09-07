using UnityEngine;

public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Puck"))
        {
            GameManager.Score(transform.name);

            hitInfo.GetComponent<PuckController>().RestartGame();
        }
    }
}