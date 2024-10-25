using UnityEngine;

namespace TDS.Game.Enemies
{
    [RequireComponent(typeof(EnemyAttack), typeof(Collider2D))]
    public class EnemyHealth : Health
    {
        #region Variables

        [SerializeField] private EnemyAnimator _enemyAnimator;

        private EnemyAttack _attack;
        private Collider2D _collider;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _attack = GetComponent<EnemyAttack>();
            _collider = GetComponent<Collider2D>();
        }

        #endregion

        #region Protected methods

        protected override void Die()
        {
            _enemyAnimator.SetIsDead();

            _attack.enabled = false;
            _collider.enabled = false;
        }

        #endregion
    }
}