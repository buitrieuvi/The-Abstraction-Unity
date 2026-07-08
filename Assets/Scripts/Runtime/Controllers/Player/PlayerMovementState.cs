using Assets.Scripts.Runtime.Interface;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Abstraction
{
    public class PlayerMovementState : IState
    {
        protected PlayerState playerState;

        protected float targetAngle;
        protected float angle;
        protected Vector3 moveDir;

        protected float turnSmoothTime = 0.1f;
        protected float turnSmoothVelocity;

        protected float speed;

        protected float modeAnimation = 0f;

        public PlayerMovementState(PlayerState playerState)
        {
            this.playerState = playerState;
        }

        public virtual void Enter()
        {


        }

        public virtual void Exit()
        {

        }

        public virtual void HandleInput()
        {
            playerState.player.Move =
                playerState.player.Input.InputActions.Player.Move.ReadValue<Vector2>();

            if (playerState.player.Move != Vector2.zero)
            {
                playerState.player.LastMove = playerState.player.Move;
            }
        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Update()
        {
            playerState.player.DistanceToGround = CheckDistanceToGrounded();

            if (playerState.player.DistanceToGround >= -1)
            {
                ApplyGravity();
            }

            playerState.player.SetAnimationSpeed();

            if (playerState.player.Move != Vector2.zero &&
                playerState.player.IsPressRunning &&
                !playerState.player.IsRunning)
            {
                playerState.ChangeState(playerState.running);
            }

            if (playerState.player.Move != Vector2.zero &&
                playerState.player.IsCtrl &&
                !playerState.player.IsSlowing)
            {
                playerState.ChangeState(playerState.slowing);
            }
        }

        protected void OnMove()
        {
            playerState.player.Speed = Mathf.Lerp(playerState.player.Speed, speed, Time.deltaTime * playerState.player.CrouchTime);
            playerState.player.AnimationSpeed = Mathf.Lerp(playerState.player.AnimationSpeed, modeAnimation, Time.deltaTime * playerState.player.CrouchTime);

            targetAngle = Mathf.Atan2(playerState.player.LastMove.x, playerState.player.LastMove.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(playerState.player.CharCtrl.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            if (playerState.player.Move != Vector2.zero) playerState.player.CharCtrl.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            playerState.player.CharCtrl.Move(moveDir.normalized * playerState.player.Speed * Time.deltaTime);
        }

        protected float CheckDistanceToGrounded()
        {
            Vector3 bottom = playerState.player.transform.position
            + Vector3.up * playerState.player.CharCtrl.center.y
            - Vector3.up * (playerState.player.CharCtrl.height / 2 - playerState.player.CharCtrl.skinWidth);

            Ray ray = new Ray(bottom, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerState.player.Layer.GroundLayer))
            {
                return hit.distance;
            }

            return -1f;
        }

        protected void ApplyGravity()
        {
            playerState.player.CharCtrl.Move(Physics.gravity * Time.deltaTime * 0.9f);
        }

        public virtual void OntriggerEnter(Collider coll)
        {

        }

        public virtual void OntriggerExit(Collider coll)
        {

        }
    }
}
