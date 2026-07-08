using UnityEngine;

namespace Abstraction
{
    public class PlayerStoping : PlayerMoving
    {
        public PlayerStoping(PlayerState playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            playerState.player.IsStoping = true;
            speed = 0;
        }

        public override void Exit()
        {
            base.Exit();
            playerState.player.IsStoping = false;
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

            if (playerState.player.Speed < 0.001f)
            {
                playerState.ChangeState(playerState.idling);
            }

            if (playerState.player.Move != Vector2.zero)
            {
                playerState.ChangeState(playerState.walking);
            }
        }
    }
}
