using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    enum MOVE_DIR { IDLE, LEFT, UP, RIGHT, DOWN }

    public float speed = 0.25f;
    private PlayerControls ctrls;

    [SerializeField]
    private Tilemap danceFloor;

    [SerializeField]
    private Animator anim;

    private bool canMove = true;

    public void Start()
    {
        ctrls.Gameplay.Movement.performed += ctx => MoveToTile(ctx.ReadValue<Vector2>());
    }

    private void Awake()
    {
        ctrls = new PlayerControls();
    }

    private void OnEnable()
    {
        ctrls.Enable();
    }

    private void OnDisable()
    {
        ctrls.Disable();
    }

    private void MoveToTile(Vector2 dir)
    {
        if (!CanMove(dir))
            return;

        transform.position += (Vector3)dir;
        if (dir.x > 0)
            anim.SetInteger("state", (int)MOVE_DIR.RIGHT);
        else if(dir.x < 0)
            anim.SetInteger("state", (int)MOVE_DIR.LEFT);
        else if(dir.y > 0)
            anim.SetInteger("state", (int)MOVE_DIR.UP);
        else if(dir.y < 0)
            anim.SetInteger("state", (int)MOVE_DIR.DOWN);

        GameManager.Instance.OnPlayerMove();
    }

    public void Reset()
    {
        anim.SetInteger("state", (int)MOVE_DIR.IDLE);
    }

    private bool CanMove(Vector2 dir)
    {
        Vector3Int pos = danceFloor.WorldToCell(transform.position + (Vector3)dir);
        return danceFloor.HasTile(pos);
    }
}
