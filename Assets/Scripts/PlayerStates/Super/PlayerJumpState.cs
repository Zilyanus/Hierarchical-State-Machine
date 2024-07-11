using System.Collections;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubState();
    }

    public override void StartState()
    {
        _context.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _context.JumpForce);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }

    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 3)
        {
            SwitchState(_factory.playerGroundedState());
        }
    }

    public override void OnCollisionExit2D(Collision2D coll)
    {

    }

    public override void ExitState()
    {
        
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void InitializeSubState()
    {
        if (_context.Horizontal == 0)
        {
            _context.ChangeSubState(_factory.PlayerIdleState());
            SetSubState(_factory.PlayerIdleState());
        }
        else
        {
            _context.ChangeSubState(_factory.PlayerRunState());
            SetSubState(_factory.PlayerRunState());
        }
    }
}