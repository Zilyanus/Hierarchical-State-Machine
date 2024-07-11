using System.Collections;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public PlayerGroundedState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
        _isRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates()
    {
        if (_context.isJumpPressed)
            SwitchState(_factory.playerJumpState());
    }

    public override void ExitState()
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

    public override void OnCollisionEnter2D(Collision2D coll)
    {
        
    }

    public override void OnCollisionExit2D (Collision2D coll)
    {
        
    }

    public override void StartState()
    {
        
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}