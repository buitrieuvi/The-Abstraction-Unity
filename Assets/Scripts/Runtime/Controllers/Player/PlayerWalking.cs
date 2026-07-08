using UnityEngine;

namespace Abstraction
{
    public class PlayerWalking : PlayerMoving
    {
        public PlayerWalking(PlayerState playerMovementStateMachine) : base(playerMovementStateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            playerState.player.IsWalking = true;

            speed = playerState.player.SpeedWalking;
            modeAnimation = 1f;
        }

        public override void Exit()
        {
            base.Exit();
            playerState.player.IsWalking = false;
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

            if (playerState.player.Move != Vector2.zero)
            {
                return;
            }

            if (playerState.player.Move == Vector2.zero)
            {
                playerState.ChangeState(playerState.stoping);
            }
        }
    }
}
