using TDS.Game.Enemies.Base;
using TDS.Game.Enemies.Gunner;
using UnityEngine;

namespace TDS.Game.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyHealth : Health
    {
        #region Variables

        [SerializeField] private GunnerAnimator _animator;
        private Collider2D _collider;

        private EnemyBehaviour[] _enemyBehaviours;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _enemyBehaviours = GetComponents<EnemyBehaviour>();
            _collider = GetComponent<Collider2D>();
        }

        #endregion

        #region Protected methods

        protected override void Die()
        {
            _animator.SetIsDead();
            DeactivateEnemyBehaviours();
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