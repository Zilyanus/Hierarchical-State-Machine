using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState CurrentState;

    PlayerStateFactory _States;

    [SerializeField] TextMeshProUGUI StateTextUI;
    [SerializeField] TextMeshProUGUI SubStateTextUI;

    public float Horizontal;
    public bool isJumpPressed;

    public float Speed = 3;
    public float JumpForce = 300;

    public float MoveVeloctiy;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _States = new PlayerStateFactory(this);
        ChangeState(_States.playerGroundedState());
    }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        isJumpPressed = Input.GetKeyDown(KeyCode.Space);

        CurrentState.UpdateStates();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(MoveVeloctiy, rb.velocity.y);
    }

    public void ChangeState(PlayerBaseState state)
    {
        CurrentState = state;
        StateTextUI.text = state.ToString();
    }

    public void ChangeSubState(PlayerBaseState state)
    {
        SubStateTextUI.text = state.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentState.OnCollisionEnter2D(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CurrentState.OnCollisionExit2D(collision);
    }
}
