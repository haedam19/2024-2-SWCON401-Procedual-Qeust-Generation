using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        switch(player.curLocation)
        {
            case GameManager.Location.Town:
                Vector2 playerPos = player.transform.position;
                float cameraX = Mathf.Clamp(playerPos.x, 5f, 13f);
                float cameraY = Mathf.Clamp(playerPos.y, -5f, -3f);
                transform.position = new Vector3(cameraX, cameraY, transform.position.z);
                break;
            case GameManager.Location.Hill:
                transform.position = new Vector3(-17f, -45f, transform.position.z);
                break;
        }
    }
}
