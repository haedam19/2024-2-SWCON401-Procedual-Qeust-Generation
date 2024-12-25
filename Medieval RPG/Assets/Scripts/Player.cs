using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : Character
{
    [HideInInspector] public GameManager.Location curLocation = GameManager.Location.Town;
    SpriteRenderer[] sprites;
    public float speed = 20f;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(dirX, dirY, 0f).normalized;
        transform.position += dir * speed * Time.deltaTime;
        if (dirX != 0)
            FlipSprites(dirX < 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // 전제: NPC 오브젝트는 NPC Layer로 설정되어 있음
            Collider2D npcCol = Physics2D.OverlapCircle(transform.position, 2.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (npcCol)
            {
                Character npc = npcCol.GetComponentInParent<Character>();
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
