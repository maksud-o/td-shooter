using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _target;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _shotCooldown = 1f;
        [SerializeField] private GunnerAnimator _gunnerAnimator;

        private float _cooldownTimer;
        private bool _inCooldown;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            ProcessCooldown();
            SeekTarget();
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

        private void SeekTarget()
        {
            Vector2 direction = (_target.position - transform.position).normalized;
            transform.up = direction;
            if (!_inCooldown)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            _gunnerAnimator.SetShot();
            Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            _inCooldown = true;
        }

        #endregion
    }
}