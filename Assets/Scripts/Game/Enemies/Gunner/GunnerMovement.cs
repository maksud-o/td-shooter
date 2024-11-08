using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    public class GunnerMovement : EnemyMovement
    {
        #region Variables

        [SerializeField] private float _movementSpeed;
        [SerializeField] private GunnerAnimator _animator;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Target is null)
            {
                _animator.SetMoveSpeed(0);
                return;
            }

            ProcessRotation();
            ProcessMovement();
        }

        private void OnDisable()
        {
            _animator.SetMoveSpeed(0);
        }

        #endregion

        #region Private methods

        private void ProcessMovement()
        {
            float speed = _movementSpeed * Time.deltaTime;
            Vector2 movement = transform.up * speed;
            _animator.SetMoveSpeed(speed);
            if (Vector3.Distance(transform.position, Target.transform.position) <= speed)
            {
                transform.position = Target.transform.position;
            }
            else
            {
                transform.Translate(movement, Space.World);
            }
        }

        private void ProcessRotation()
        {
            transform.up = (Target.position - transform.position).normalized;
        }

        #endregion
    }
}