namespace Abstraction
{
    public class PlayerFall : PlayerAirborne
    {
        public PlayerFall(PlayerState playerState) : base(playerState)
        {
        }

        public override void Enter()
        {
            base.Enter();
            playerState.player.IsFalling = true;
        }

        public override void Exit()
        {
            base.Exit();
            playerState.player.IsFalling = false;
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
