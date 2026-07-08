using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Abstraction
{

    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _gameObj;
        [Inject] private InputManager _input;

        Stack<ParticleSystem> _pooling = new();
        public Stack<ParticleSystem> Pooling => _pooling;

        public bool isSpaced;
        public bool canSpaced = true;

        [Range(0.01f,2f)] public float Speed = 0.2f;

        public bool Tab;


        private void Start()
        {
            for (int i = 0; i < 20; i++)
            {
                var obj = Instantiate(_gameObj, transform);
                obj.gameObject.SetActive(false);
            }

            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                _pooling.Push(transform.GetChild(i).GetComponent<ParticleSystem>());
            }

            _input.InputActions.Player.Space.performed += (e) =>
            {
                isSpaced = _input.InputActions.Player.Space.IsPressed();
                if (Tab) Shoot();
            };

            _input.InputActions.Player.Space.canceled += (e) =>
            {
                isSpaced = _input.InputActions.Player.Space.IsPressed();
            };

        }


        private async void Update()
        {
            if (isSpaced && canSpaced) 
            {
                if (Tab) return;
                canSpaced = false;

                Shoot();

                await UniTask.WaitForSeconds(Speed);
                canSpaced = true;
            }
        }

        void Shoot()
        {
            if (_pooling.Count == 0)
            {

                var obj = Instantiate(_gameObj, transform);
                obj.gameObject.SetActive(false);

                _pooling.Push(obj);
            }
            transform.position = Camera.main.transform.position;
            transform.rotation = Camera.main.transform.rotation;
            var p = _pooling.Pop();
            p.gameObject.SetActive(true);
        }
    }
}