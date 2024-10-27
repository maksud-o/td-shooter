using UnityEngine;
using UnityEngine.InputSystem;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private InputActionReference _shootAction;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _shotCooldown = .2f;
        [SerializeField] private PlayerAnimator _playerAnimator;

        private float _cooldownTimer;
        private bool _inCooldown;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            ProcessCooldown();
        }

        private void OnEnable()
        {
            _shootAction.action.performed += ShootActionPerformedCallback;
        }

        private void OnDisable()
        {
            _shootAction.action.performed -= ShootActionPerformedCallback;
        }

        #endregion

        #region Private methods

        private void ProcessCooldown()
        {
            if (_inCooldown && _cooldownTimer > 0)
            {
                _cooldownTimer -= Time.deltaTime;
            }
            else if (_cooldownTimer <= 0)
            {
                _inCooldown = false;
                _cooldownTimer = _shotCooldown;
            }
        }

        private void ShootActionPerformedCallback(InputAction.CallbackContext ctx)
        {
            if (!_inCooldown)
            {
                _playerAnimator.SetShot();
                Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
                _inCooldown = true;
            }
        }

        #endregion
    }
}