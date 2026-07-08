namespace Abstraction
{
    public class PlayerGrounded : PlayerMovementState
    {
        public PlayerGrounded(PlayerState playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            playerState.player.IsGrounded = true;
        }

        public override void Exit()
        {
            base.Exit();
            playerState.player.IsGrounded = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
