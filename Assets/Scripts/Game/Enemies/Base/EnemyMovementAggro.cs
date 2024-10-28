using TDS.Architecture;
using UnityEngine;

namespace TDS.Game.Enemies.Base
{
    [RequireComponent(typeof(EnemyMovement), typeof(EnemyIdle))]
    public class EnemyMovementAggro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        private EnemyIdle _idle;
        private EnemyMovement _movement;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            _idle = GetComponent<EnemyIdle>();
        }

        private void OnEnable()
        {
            _triggerObserver.OnEnter += TriggerEnter2DCallback;
            _triggerObserver.OnExit += TriggerExit2DCallback;
        }

        private void OnDisable()
        {
            _triggerObserver.OnEnter -= TriggerEnter2DCallback;
            _triggerObserver.OnExit -= TriggerExit2DCallback;
        }

        #endregion

        #region Private methods

        private void TriggerEnter2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }

            _idle.Deactivate();
            _movement.Activate();
            _movement.SetTarget(other.transform);
        }

        private void TriggerExit2DCallback(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER))
            {
                return;
            }

            _idle.Activate();
            _movement.Deactivate();
            _movement.SetTarget(null);
        }

        #endregion
    }
}