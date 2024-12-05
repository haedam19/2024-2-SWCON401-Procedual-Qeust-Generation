using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public GameManager.Location curLocation = GameManager.Location.Town;
    SpriteRenderer[] sprites;

    public float speed = 20f;

    // Start is called before the first frame update
    void Awake()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(dirX, dirY, 0f).normalized;
        transform.position += dir * speed * Time.deltaTime;
        if (dirX != 0)
            FlipSprites(dirX < 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject npcObj = Physics2D.OverlapCircle(transform.position, 2.5f, 1 << LayerMask.NameToLayer("NPC")).gameObject;
            if (npcObj)
            {
                Character npc = npcObj.GetComponentInParent<Character>();
                MessageManager.Instance.StartDialog(npc, "Hi, do you need any help?");
            }
        }
    }

    void FlipSprites(bool flip)
    {
        foreach(SpriteRenderer sp in sprites)
            sp.flipX = flip;
    }
}
