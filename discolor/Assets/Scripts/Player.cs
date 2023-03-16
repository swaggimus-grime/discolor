using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float speed = 0.25f;
    private PlayerControls ctrls;

    [SerializeField]
    private Tilemap danceFloor;

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
        GameManager.Instance.OnPlayerMove();
    }

    private bool CanMove(Vector2 dir)
    {
        Vector3Int pos = danceFloor.WorldToCell(transform.position + (Vector3)dir);
        return danceFloor.HasTile(pos);
    }
}
