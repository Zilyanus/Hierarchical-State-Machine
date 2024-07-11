using System.Collections;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    public PlayerIdleState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void StartState()
    {

    }

    public override void UpdateState()
    {
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
        
    }

    public override void CheckSwitchStates()
    {
        if (_context.Horizontal != 0)
        {
            SwitchState(_factory.PlayerRunState());
        }
    }

    public override void InitializeSubState()
    {

    }
}