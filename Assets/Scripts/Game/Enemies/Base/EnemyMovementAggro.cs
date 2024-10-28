using UnityEngine;

namespace TDS.Game.Enemies.Base
{
    public abstract class EnemyMovementAggro : EnemyBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        #region Unity lifecycle

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

        #region Protected methods

        protected abstract void TriggerEnter2DCallback(Collider2D other);

        protected abstract void TriggerExit2DCallback(Collider2D other);

        #endregion
    }
}