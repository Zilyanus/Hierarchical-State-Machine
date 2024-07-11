using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerBaseState
{
    protected bool _isRootState = false;
    protected PlayerStateManager _context;
    protected PlayerStateFactory _factory;

    protected PlayerBaseState _currentSubState;
    protected PlayerBaseState _currentSuperState;

    public PlayerBaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    {
        _context = currentContext;
        _factory = playerStateFactory;
    }

    public abstract void StartState();
    public abstract void UpdateState();

    public abstract void CheckSwitchStates();
    public abstract void OnCollisionEnter2D(Collision2D coll);
    public abstract void OnCollisionExit2D(Collision2D coll);

    public abstract void InitializeSubState();

    public abstract void ExitState();

    public void UpdateStates()
    {
        UpdateState();
        if (_currentSubState != null)
        {
            _currentSubState.UpdateState();
        }
    }

    protected void SwitchState(PlayerBaseState newState)
    {
        ExitState();

        newState.StartState();

        if (_isRootState)
            _context.ChangeState(newState);
        else if (_currentSuperState != null)
        {
            _context.ChangeSubState(newState);
            _currentSuperState.SetSubState(newState);
        }
    }

    protected void SetSuperState(PlayerBaseState newSuperState)
    {
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState)
    {
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}
