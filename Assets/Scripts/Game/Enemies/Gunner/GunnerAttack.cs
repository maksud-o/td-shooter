using System.Collections;
using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    public class GunnerAttack : EnemyAttack
    {
        #region Variables

        [SerializeField] private GunnerAnimator _animator;
        [SerializeField] private float _attackCooldown = 1f;
        [Header("Bullet")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPoint;

        private bool _inCooldown;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            ProcessAttack();
        }

        #endregion

        #region Private methods

        private IEnumerator CooldownRoutine()
        {
            _inCooldown = true;
            yield return new WaitForSeconds(_attackCooldown);
            _inCooldown = false;
        }

        private void ProcessAttack()
        {
            if (!_inCooldown)
            {
                Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
                StartCoroutine(CooldownRoutine());
            }
        }

        #endregion
    }
}