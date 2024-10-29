using TDS.Architecture;
using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    [RequireComponent(typeof(EnemyMovementAggro), typeof(EnemyAttack))]
    public class GunnerAttackAggro : EnemyAttackAggro
    {
        #region Variables

        private EnemyAttack _attack;
        private EnemyMovementAggro _movementAggro;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _movementAggro = GetComponent<EnemyMovementAggro>();
            _attack = GetComponent<EnemyAttack>();
            
            _attack.Deactivate();
        }

        #endregion

        #region Protected methods

        protected override void TriggerEnter2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }
            
            _attack.Activate();
        }

        protected override void TriggerExit2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }

            _movementAggro.Activate();
            _attack.Deactivate();
        }

        #endregion
    }
}