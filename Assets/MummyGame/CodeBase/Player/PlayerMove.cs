using System;
using MummyGame.CodeBase.Infrastructure;
using MummyGame.CodeBase.Services.Input;
using UnityEngine;

namespace MummyGame.CodeBase.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        private CharacterController _controller;
        [SerializeField] private float _speed = 10f;
        
        private IInputService _inputService;

        private void Awake()
        {
            _controller = gameObject.GetComponent<CharacterController>();
            _inputService = GameBootstrapper.InputService;
        }
        
        private void Update()
        {
            Move();
        }

        public void Move()
        {
            Vector3 movementVector = _inputService.Axis;
            movementVector.Normalize();
            _controller.Move(movementVector * _speed * Time.deltaTime);
        }
    }
}