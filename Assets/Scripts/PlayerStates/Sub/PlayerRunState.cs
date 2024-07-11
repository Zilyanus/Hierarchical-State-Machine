using System.Collections;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{

    public PlayerRunState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void StartState()
    {
        
    }

    public override void UpdateState()
    {
        _context.MoveVeloctiy = _context.Horizontal * _context.Speed;
        CheckSwitchStates();
    }

    public override void OnCollisionEnter2D(Collision2D coll)
    {

    }

    public override void OnCollisionExit2D(Collision2D coll)
    {

    }

    public override void ExitState()
    {
        _context.MoveVeloctiy = 0;
    }

    public override void CheckSwitchStates()
    {
       if (_context.Horizontal == 0)
       {
            SwitchState(_factory.PlayerIdleState());
       }
    }

    public override void InitializeSubState()
    {

    }
}