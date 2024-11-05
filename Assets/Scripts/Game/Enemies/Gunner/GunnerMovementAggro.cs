using TDS.Architecture;
using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    [RequireComponent(typeof(EnemyMovement), typeof(EnemyPatrol))]
    public class GunnerMovementAggro : EnemyMovementAggro
    {
        #region Variables

        private EnemyMovement _movement;
        private EnemyPatrol _patrol;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _patrol = GetComponent<EnemyPatrol>();

            _movement.Deactivate();
            _patrol.Deactivate();
        }

        private void Update()
        {
            if (!_patrol.enabled && !_movement.enabled)
            {
                _patrol.Activate();
            }
        }

        #endregion

        #region Protected methods

        protected override void TriggerEnter2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }

            _patrol.Deactivate();
            _movement.Activate();
            _movement.SetTarget(other.transform);
        }

        protected override void TriggerExit2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }

            _movement.SetTarget(null);
            _movement.Deactivate();
            _patrol.Activate();
        }

        #endregion
    }
}