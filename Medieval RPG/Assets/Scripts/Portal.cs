using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Vector2 destCoord;
    [SerializeField] GameManager.Location destLocation;

    void Awake()
    {
        destCoord = transform.Find("Destination").transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Player player;
        if(col.TryGetComponent<Player>(out player))
        {
            col.transform.position = (Vector3)destCoord;
            player.curLocation = destLocation;
        }
    }
}
