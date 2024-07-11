public class PlayerStateFactory
{
    PlayerStateManager _context;

    public PlayerStateFactory(PlayerStateManager currentContext)
    {
        _context = currentContext;
    }

    public PlayerIdleState PlayerIdleState() { return new PlayerIdleState(_context,this);}
    public PlayerRunState PlayerRunState() { return new PlayerRunState(_context,this);}
    public PlayerJumpState playerJumpState() { return new PlayerJumpState(_context,this);}
    public PlayerGroundedState playerGroundedState() { return new PlayerGroundedState(_context,this);}
}