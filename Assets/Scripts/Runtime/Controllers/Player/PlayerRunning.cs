using UnityEngine;

namespace Abstraction
{
    public class PlayerRunning : PlayerMoving
    {
        public PlayerRunning(PlayerState playerMovementStateMachine) : base(playerMovementStateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            playerState.player.IsRunning = true;
            speed = playerState.player.SpeedRunning;

            modeAnimation = 2f;
        }

        public override void Exit()
        {
            base.Exit();
            playerState.player.IsRunning = false;
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

            if (!playerState.player.IsPressRunning || playerState.player.Move == Vector2.zero)
            {
                playerState.ChangeState(playerState.stoping);
                return;
            }
        }
    }
}
