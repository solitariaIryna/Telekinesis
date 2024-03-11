using Code.Infrastructure.Services;
using Code.StaticData;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Items.States
{
    public class ItemLevitationState : ItemState, IUpdatebleState
    {
        private readonly IItemLevitationStateData _staticData;
        private readonly IInputService _inputService;
        private readonly Camera _camera;

        private Vector3 _rotationSide;

        private float _timer;
        private float _delayUntilChangeSide;

        private float _magnitude;

        private Transform _target;
        
        public ItemLevitationState(Item stateMachine, ItemInfo itemInfo,
            IItemLevitationStateData staticData, IInputService inputService, Camera camera) : base(stateMachine, itemInfo)
        {
            _staticData = staticData;
            _inputService = inputService;
            _camera = camera;
        }

        public void Enter()
        {
            _stateMachine.AttackOrFall += ChangeState;
            _stateMachine.Follow += Follow;
            
            _rotationSide = Vector3.up;
            RandomizeDelayUntilChangeSide();
            RiseUp();
        }
        
        public void Update()
        {
            Rotate();
            CountDownToChangeSide();
            Levitate();
            
        }
        public void Exit()
        {
            _stateMachine.AttackOrFall -= ChangeState;
            LeanTween.cancel(_itemInfo.Transform.gameObject); 
            _timer = 0;
            
        }
        private void RiseUp() => 
            LeanTween.moveY(_itemInfo.Transform.gameObject, _staticData.Height, _staticData.RiseTime);
        private void Follow(Transform target)
        {
            _target = target;
        }
        private void ChangeState()
        {
            if (_magnitude > 0.1f)
            {
                _stateMachine.Enter<ItemAttackState>();
            }
                
            else
                _stateMachine.Enter<ItemFallState>();
        }

        private void Rotate() => 
            _itemInfo.Transform.Rotate(_rotationSide, _staticData.RotationSpeedAroundAxis * Time.deltaTime);

        private void Levitate()
        {
            Vector3 movementVector = Vector3.zero;
            
            _magnitude = _inputService.InteractionAxis.sqrMagnitude;
            
            if (_magnitude > 0.05f)
            {
              
                movementVector = _camera.transform.TransformDirection(_inputService.InteractionAxis);
                movementVector.y = 0;
                
                _itemInfo.Direction = movementVector.normalized;
               
            }
            
            CalculatePosition();
            
        }
        private void ClampPositionY() =>
            _itemInfo.Position = new Vector3(_itemInfo.Position.x, Mathf.Clamp(_itemInfo.Position.y, 0, _staticData.Height),
                _itemInfo.Position.z);
        private float Distance(Vector3 position) =>
            Mathf.Clamp(Vector3.Distance(_target.position, position), 1.3f, 3);
        private void CalculatePosition()
        {
            Vector3 position = _itemInfo.Position + (_itemInfo.Direction * (_staticData.MoveSpeed * Time.deltaTime));
            
            Vector3 direction = (position - _target.position).normalized;
            float distance = Distance(position);
            
            _itemInfo.Position = _target.position + distance * direction;
            
            ClampPositionY();
        }

        private void CountDownToChangeSide()
        {
            _timer += Time.deltaTime;

            if (_timer >= _delayUntilChangeSide)
            {
                ChangeRotateSide();
                RandomizeDelayUntilChangeSide();
                _timer = 0;
            }
        }

        private void RandomizeDelayUntilChangeSide() => 
            _delayUntilChangeSide = Random.Range(_staticData.MinTimeToChangeSide, _staticData.MaxTimeToChangeSide);

        private void ChangeRotateSide()
        {
            if (Random.value >= _staticData.ChanceChangeSide)
                _rotationSide *= -1;
        }
    }
}
