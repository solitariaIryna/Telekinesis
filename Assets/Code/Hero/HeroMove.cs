using Code.Infrastructure.CameraLogic;
using Code.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Code.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;
        private Camera _camera;

        [Inject]
        private void Construct(IInputService inputSetvice) => 
            _inputService = inputSetvice;
        private void Start() => 
            CameraFollow();

        private void CameraFollow()
        {
            _camera = Camera.main;

            _camera.GetComponent<CameraFollow>().Follow(transform);
        }

        private void Update() => 
            Move();
        private void Move()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.MoveAxis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.MoveAxis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }
            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}