﻿using Assets.CodeBase.CameraLogic;
using Assets.CodeBase.Infrastructure;
using Assets.CodeBase.Services.Input;
using CodeBase;
using UnityEngine;

namespace Assets.CodeBase.Hero
{
    public class HeroMove : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MovementSpeed;

        private IInputService _inputService;
        private Camera _camera;

        void Awake()
        {
            _inputService = Game.InputService;
        }

        void Start()
        {
            _camera = Camera.main;
            CameraFollow();
        }

        void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
            CharacterController.Move(movementVector * Time.deltaTime * MovementSpeed);
        }

        private void CameraFollow() => 
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
    }
}