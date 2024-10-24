using UnityEngine;
using UnityEngine.InputSystem;

namespace TDS.Game
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private InputActionReference _shootAction;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPoint;

        [SerializeField] private PlayerAnimator _playerAnimator;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _shootAction.action.performed += ShootActionPerformedCallback;
        }

        private void OnDestroy()
        {
            _shootAction.action.performed -= ShootActionPerformedCallback;
        }

        #endregion

        #region Private methods

        private void ShootActionPerformedCallback(InputAction.CallbackContext ctx)
        {
            _playerAnimator.SetShot();
            Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        }

        #endregion
    }
}