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
                return;
            }

            ProcessRotation(); // TODO: visual bug when near target
            ProcessMovement();
        }

        #endregion

        #region Private methods

        private void ProcessMovement()
        {
            float speed = _movementSpeed * Time.deltaTime;
            Vector2 movement = transform.up * speed;
            _animator.SetMoveSpeed(speed);
            transform.Translate(movement, Space.World);
        }

        private void ProcessRotation()
        {
            transform.up = (Target.position - transform.position).normalized;
        }

        #endregion
    }
}