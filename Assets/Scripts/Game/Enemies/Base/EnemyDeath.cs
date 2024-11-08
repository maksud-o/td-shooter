using TDS.Game.Enemies.Gunner;
using UnityEngine;

namespace TDS.Game.Enemies.Base
{
    [RequireComponent(typeof(Health), typeof(Collider2D))]
    public class EnemyDeath : Death
    {
        #region Variables

        [SerializeField] private GunnerAnimator _animator;
        private Collider2D _collider;

        private EnemyBehaviour[] _enemyBehaviours;
        private Health _health;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _enemyBehaviours = GetComponents<EnemyBehaviour>();
            _collider = GetComponent<Collider2D>();
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.OnZeroHealth += Die;
        }

        private void OnDisable()
        {
            _health.OnZeroHealth -= Die;
        }

        #endregion

        #region Protected methods

        protected override void Die()
        {
            _animator.SetIsDead();
            DeactivateEnemyBehaviours();
            _collider = GetComponent<Collider2D>();
        }

        #endregion

        #region Private methods

        private void DeactivateEnemyBehaviours()
        {
            foreach (EnemyBehaviour behaviour in _enemyBehaviours)
            {
                behaviour.Deactivate();
                _collider.enabled = false;
            }
        }

        #endregion
    }
}