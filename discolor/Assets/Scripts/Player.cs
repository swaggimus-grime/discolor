using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public enum MOVE_DIR { IDLE, LEFT, UP, RIGHT, DOWN }

    enum ARROW_STATE { IDLE, MOVE, BLOCK }

    public float speed = 0.25f;
    private PlayerControls ctrls;

    [SerializeField]
    private Tilemap danceFloor;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Animator leftAnim;
    [SerializeField]
    private Animator rightAnim;
    [SerializeField]
    private Animator upAnim;
    [SerializeField]
    private Animator downAnim;

    private Dictionary<Vector2, MOVE_DIR> availableDirs;
    private Vector2 previousDir;

    public void Start()
    {
        availableDirs = new Dictionary<Vector2, MOVE_DIR>();
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

    private bool colorEquals(Color c1, Color c2)
    {
        return c1.r == c2.r && c1.g == c2.g && c1.b == c2.b;
    }
    private void MoveToTile(Vector2 dir)
    {
        if (!CanMove(dir))
            return;

        Vector3Int futurePos = danceFloor.WorldToCell(transform.position + (Vector3)dir);
        Color futureColor = danceFloor.GetColor(futurePos);
        Vector3Int currentPos = danceFloor.WorldToCell(transform.position);
        Color currentColor = danceFloor.GetColor(currentPos);
        bool complementary = colorEquals((Color.white - currentColor), futureColor);
        if (!complementary)
        {
            availableDirs.Remove(dir);
            SetArrowState(dir, ARROW_STATE.BLOCK);
        }
        else
        {
            SetArrowState(dir, ARROW_STATE.MOVE);
            SetArrowState(previousDir, ARROW_STATE.IDLE);
            previousDir = dir;
        }

        SetAnimState(dir);
        transform.position += (Vector3)dir;
        GameManager.Instance.OnPlayerMove();
    }

    public void Reset()
    {
        availableDirs.Clear();
        availableDirs.Add(new Vector2(-1, 0), MOVE_DIR.LEFT);
        availableDirs.Add(new Vector2(1, 0), MOVE_DIR.RIGHT);
        availableDirs.Add(new Vector2(0, 1), MOVE_DIR.UP);
        availableDirs.Add(new Vector2(0, -1), MOVE_DIR.DOWN);
        previousDir = new Vector2(0, 0);
        foreach (Vector2 dir in availableDirs.Keys)
            SetArrowState(dir, ARROW_STATE.IDLE);
        anim.SetInteger("state", (int)MOVE_DIR.IDLE);
    }

    private void SetArrowState(Vector2 dir, ARROW_STATE state)
    {
        if (dir.x > 0)
            rightAnim.SetInteger("state", (int)state);
        else if (dir.x < 0)
            leftAnim.SetInteger("state", (int)state);
        else if (dir.y > 0)
            upAnim.SetInteger("state", (int)state);
        else if (dir.y < 0)
            downAnim.SetInteger("state", (int)state);
    }
    private void SetAnimState(Vector2 dir)
    {
        if (dir.x > 0)
        {
            anim.SetInteger("state", (int)MOVE_DIR.RIGHT);
        }
        else if (dir.x < 0)
        {
            anim.SetInteger("state", (int)MOVE_DIR.LEFT);
        }
        else if (dir.y > 0)
        {
            anim.SetInteger("state", (int)MOVE_DIR.UP);
        }
        else if (dir.y < 0)
        {
            anim.SetInteger("state", (int)MOVE_DIR.DOWN);
        }
    }

    private bool CanMove(Vector2 dir)
    {
        Vector3Int pos = danceFloor.WorldToCell(transform.position + (Vector3)dir);
        return danceFloor.HasTile(pos) && availableDirs.ContainsKey(dir);
    }
}
