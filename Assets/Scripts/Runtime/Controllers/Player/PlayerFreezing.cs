namespace Abstraction
{
    public class PlayerFreezing : PlayerMovementState
    {
        public PlayerFreezing(PlayerState playerState) : base(playerState)
        {

        }

        public override void Enter()
        {
            playerState.player.Input.InputActions.FindAction("Move").Disable();
            base.Enter();
        }

        public override void Exit()
        {
            playerState.player.Input.InputActions.FindAction("Move").Enable();
            base.Exit();
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
            if (playerState.player.Speed > 0.1f)
            {
                OnMove();
            }
        }
    }
}
