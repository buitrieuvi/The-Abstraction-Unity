using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.Windows;
using Zenject;

namespace Abstraction
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] public InputManager Input { get; private set; }
        [Inject] public LayerController Layer { get; private set; }
        [Inject] public GameDataManager GameData { get; private set; }

        public CharacterController CharCtrl { get; private set; }
        public PlayerState Movement { get; private set; }

        public EventTrigger CurrentTrigger;

        [Header("Movement")]
        public Vector2 Move;
        public Vector2 LastMove;

        public bool IsRunningMode;
        public bool IsPressRunning;
        public bool IsCtrl;
        public bool IsAlt;

        public float CrouchTime = 10f;
        public float SpeedSlowing = 2f;
        public float SpeedWalking = 5f;
        public float SpeedRunning = 8f;
        public float Speed;
        public bool IsGrounded;
        public bool IsIdling;
        public bool IsWalking;
        public bool IsSlowing;
        public bool IsRunning;
        public bool IsMoving;
        public bool IsStoping;
        public float DistanceToGround;
        public bool IsAirbone;
        public bool IsFalling;

        [Header("Animation")]
        public float AnimationSpeed;
        public Animator Animator;

        string _animSpeed = "speed";
        int _praSpeed;

        private void Awake()
        {
            CharCtrl = GetComponent<CharacterController>();

            Movement = new PlayerState(this);
            Movement.ChangeState(Movement.idling);

            InitAnimation();
        }

        public void Start()
        {

            //Input.InputActions.Player.Esc.started += async ctx =>
            //{
            //    //await Panel.OnInputAction<View_Menu>();
            //};

            Input.InputActions.Player.Interact.started += ctx => CurrentTrigger?.OnInteract();
            Input.InputActions.Player.Alt.started += ctx => Alt();

            Input.InputActions.Player.Ctrl.performed += ctx => Ctrl();
            Input.InputActions.Player.Ctrl.canceled += ctx => Ctrl();

            Input.InputActions.Player.Sprint.performed += ctx => PressRunning();
            Input.InputActions.Player.Sprint.canceled += ctx => PressRunning();
        }

        public void InitAnimation()
        {
            Animator = GetComponentInChildren<Animator>();
            _praSpeed = Animator.StringToHash(_animSpeed);
        }

        public void SetAnimationSpeed()
        {
            Animator.SetFloat(_praSpeed, AnimationSpeed);
        }

        public void Update()
        {
            Movement.HandleInput();
            Movement.Update();
        }

        public void FixedUpdate()
        {
            Movement.PhysicsUpdate();
        }

        public void OnTriggerEnter(Collider other)
        {
            Movement.OntriggerEnter(other);

            var ET = other.GetComponent<EventTrigger>();
            if (ET != null) 
            {
                CurrentTrigger = ET;
                CurrentTrigger.TriggerEnter();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            Movement.OntriggerExit(other);

            var ET = other.GetComponent<EventTrigger>();
            if (ET != null)
            {
                CurrentTrigger.TriggerExit();
                CurrentTrigger = null;
            }
        }


        public void Shift()
        {
            if (IsRunningMode)
            {
                IsPressRunning = true;
                return;
            }
            IsPressRunning = !IsPressRunning;
        }

        public void Ctrl()
        {
            IsCtrl = !IsCtrl;
            //IsRunningMode = !IsRunningMode;

            //if (!IsRunningMode)
            //{
            //    IsPressRunning = false;
            //}
            //else
            //{
            //    IsPressRunning = true;
            //}
        }

        public void PressRunning()
        {
            if (IsRunningMode) return;
            IsPressRunning = !IsPressRunning;
        }

        public void Alt()
        {
            IsAlt = !IsAlt;
        }
    }
}
