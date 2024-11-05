using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    [RequireComponent(typeof(EnemyMovementAggro))]
    public class GunnerAttackAggro : EnemyAttackAggro
    {
        #region Variables

        private EnemyMovementAggro _movementAggro;

        #endregion

        #region Unity lifecycle

        protected override void Awake()
        {
            base.Awake();
            _movementAggro = GetComponent<EnemyMovementAggro>();
        }

        #endregion

        #region Protected methods

        protected override void TriggerEnter2DCallback(Collider2D other)
        {
            base.TriggerEnter2DCallback(other);

            _movementAggro.Deactivate();
        }

        protected override void TriggerExit2DCallback(Collider2D other)
        {
            base.TriggerExit2DCallback(other);

            _movementAggro.Activate();
        }

        #endregion
    }
}