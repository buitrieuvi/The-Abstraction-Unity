using UnityEngine;

namespace Abstraction
{
    public class PlayerSlowing : PlayerMoving
    {
        public PlayerSlowing(PlayerState playerMovementStateMachine) : base(playerMovementStateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            playerState.player.IsSlowing = true;
            speed = playerState.player.SpeedSlowing;
            modeAnimation = 1f;
        }

        public override void Exit()
        {
            base.Exit();
            playerState.player.IsSlowing = false;
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

            if (!playerState.player.IsCtrl || playerState.player.Move == Vector2.zero)
            {
                playerState.ChangeState(playerState.stoping);
                return;
            }

        }
    }
}
