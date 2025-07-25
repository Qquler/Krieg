using UnityEngine;

public class tESTIC : MonoBehaviour
{
    [SerializeField] private Transform target;
    private bool isPlayerVisible;
    void Update()
    {
        RaycastHit2D hit;
        Vector2 directionToPlayer = (target.position - transform.position);
        directionToPlayer.Normalize();

        hit = Physics2D.Raycast(transform.position, directionToPlayer, 1000f);

        Debug.DrawRay(transform.position, directionToPlayer * 100f);
        if (hit != null)
        {
            Debug.Log("FF1F");

            if (hit.collider.CompareTag("Player"))
            {
                isPlayerVisible = true;
                isPlayerVisible = true;

                Debug.Log('T');
            }
            else if (hit.collider.CompareTag("Wall"))
            {
                isPlayerVisible = false;
            }
        }

    }
}
