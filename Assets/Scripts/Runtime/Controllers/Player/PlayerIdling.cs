using UnityEngine;

namespace Abstraction
{
    public class PlayerIdling : PlayerGrounded
    {
        public PlayerIdling(PlayerState playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        
        }

        public override void Enter()
        {
            base.Enter();
            playerState.player.IsIdling = true;
            playerState.player.Speed = 0f;

            playerState.player.AnimationSpeed = 0f;
            modeAnimation = 0f;
        }

        public override void Exit()
        {
            base.Exit();
            playerState.player.IsIdling = false;
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

            if (playerState.player.Move == Vector2.zero)
            {
                return;
            }

            playerState.ChangeState(playerState.walking);
        }
    }
}
